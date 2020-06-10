using Core.Entities;
using Core.Enumerations;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.ViewModels.Apis;
using Core.ViewModels.Aviation;
using Core.ViewModels.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PUSGS_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository repository;
        private readonly ApplicationSettings settings;
        private readonly IFlightService _flightService;

        public UserController(IUserRepository userRepository, IOptions<ApplicationSettings> appSettings, IFlightService flightService)
        {
            repository = userRepository;
            settings = appSettings.Value;
            _flightService = flightService;
        }

        // GET: api/User
        [HttpGet]
        public async Task<List<UserModel>> Get()
        {
            var users = await repository.GetUsersAsync();
            return users.Select(u => new UserModel(u)).ToList();
        }

        // GET: api/User/5
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        [HttpGet("{id}", Name = "Get")]
        public async Task<object> Get(string id)
        {
            var user = await repository.GetUserByEmailAsync(id);
            if (user == null)
            {
                return new NotFoundResult();
            }
            return new OkObjectResult(new UserModel(user));
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public Task Put(string id, [FromBody] User user)
        {
            user.Email = id;
            return repository.UpdateAsync(user);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public Task Delete(string id)
        {
            return repository.DeleteUserByEmailAsync(id);
        }

        [HttpGet]
        [Route("{id}/flight-history")]
        public Task<List<FlightTicketDetailsModel>> GetFlightTicketHistory(string id)
        {
            return _flightService.GetFlightTicketHistoryForUserAsync(id);
        }

        [HttpPost]
        [Route("Friend")]
        public Task MakeFriends([FromBody]FriendRequestModel request)
        {
            return repository.MakeFriendsAsync(request.UserId, request.FriendId);
        }

        [HttpPost]
        [Route("Unfriend")]
        public Task Unfriend([FromBody]FriendRequestModel request)
        {
            return repository.UnfriendAsync(request.UserId, request.FriendId);
        }

        [HttpPost]
        [Route("Register")]
        public async Task<object> Register([FromBody] User model)
        {
            User user = MapUser(model);

            if (!await repository.AddAsync(user))
            {
                return BadRequest(new { message = "Already exist" });
            }

            await SendConfirmationEmailAsync(user.Email);

            return Ok();
        }

        [HttpPost]
        [Route("Login")]
        public async Task<object> Login([FromBody] LoginModel model)
        {
            var user = await repository.GetUserByEmailAsync(model.Email);

            if (user is null || model.Password != user.Password)
            {
                return BadRequest(new { message = "Invalid username or password" });
            }

            if (!user.IsVerified)
            {
                return BadRequest(new { message = "Email not verified" });
            }

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(AppConsts.CLAIM_TOKEN_KEY, user.Email)
                }),
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(securityToken);
            return Ok(new { token, type = user.GetType().Name });
        }

        [HttpPost]
        [Route("SocialLogin")]
        public async Task<object> SocialLogin([FromBody] LoginModel model)
        {
            var tokenVerification = await VerifyTokenAsync(model.IdToken);
            if (tokenVerification.isVaild)
            {
                var user = await repository.GetUserByEmailAsync(tokenVerification.apiTokenInfo.email);
                if (user is null)
                {
                    await repository.AddAsync(new User() { Email = tokenVerification.apiTokenInfo.email, Name = model.FirstName, LastName = model.LastName, IsVerified = true });
                }

                var tokenDescriptor = new SecurityTokenDescriptor()
                {
                    Expires = DateTime.UtcNow.AddMinutes(5),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                return Ok(new { token, type = typeof(User).Name });
            }

            return BadRequest(new { message = "Error loging in with google" });
        }

        [HttpPost]
        [Route("ConfirmEmail")]
        public async Task<object> ConfirmEmailAsync(LoginModel model)
        {
            var user = await repository.GetUserByEmailAsync(model.Email);
            if (user is null)
            {
                return BadRequest(new { message = "Error processing email" });
            }
            user.IsVerified = true;
            await repository.UpdateAsync(user);
            return Ok();
        }

        private async Task<(bool isVaild, GoogleApiTokenInfo apiTokenInfo)> VerifyTokenAsync(string providerToken)
        {
            var httpClient = new HttpClient();
            var requestUri = new Uri($"https://www.googleapis.com/oauth2/v3/tokeninfo?id_token={providerToken}");

            HttpResponseMessage responseMessage;

            try
            {
                responseMessage = await httpClient.GetAsync(requestUri);
            }
            catch (Exception)
            {
                return (false, null);
            }

            if (responseMessage.StatusCode != HttpStatusCode.OK)
            {
                return (false, null);
            }

            var response = await responseMessage.Content.ReadAsStringAsync();
            var googleApiTokenInfo = JsonConvert.DeserializeObject<GoogleApiTokenInfo>(response);
            return (true, googleApiTokenInfo);
        }

        private async Task SendConfirmationEmailAsync(string email)
        {
            var client = new SmtpClient("smtp.gmail.com", 25);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential(@"srki.miki@gmail.com", "twshdabuaclmjkfw");
            using (var message = new MailMessage())
            {
                message.To.Add("srki.miki@gmail.com");
                //message.To.Add(email);
                message.From = new MailAddress(@"noreply@gmail.com");
                message.Subject = "Email verification";
                message.Body = $"<a href=\"http://localhost:4200/ConfirmEmail/{email}\">Confirm Email</a>";
                message.IsBodyHtml = true;
                message.Priority = MailPriority.High;

                await client.SendMailAsync(message);
            }
        }

        private static User MapUser(User model)
        {
            if (model.IsSystemAdmin)
            {
                return new SystemAdministrator()
                {
                    City = model.City,
                    Email = model.Email,
                    LastName = model.LastName,
                    Name = model.Name,
                    Password = model.Password,
                    Phone = model.Phone,
                    IsSystemAdmin = model.IsSystemAdmin,
                    IsRentACarAdmin = false
                };
            }
            else if (model.IsRentACarAdmin)
            {
                return new RentACarAdministrator()
                {
                    City = model.City,
                    Email = model.Email,
                    LastName = model.LastName,
                    Name = model.Name,
                    Password = model.Password,
                    Phone = model.Phone,
                    IsRentACarAdmin = model.IsRentACarAdmin,
                    IsSystemAdmin = false
                };
            }
            else
            {
                return new User()
                {
                    City = model.City,
                    Email = model.Email,
                    LastName = model.LastName,
                    Name = model.Name,
                    Password = model.Password,
                    Phone = model.Phone,
                    IsSystemAdmin = false,
                    IsRentACarAdmin = false
                };
            }
        }
    }
}