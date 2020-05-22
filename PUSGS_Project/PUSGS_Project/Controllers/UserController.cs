using Core.Entities;
using Core.Enumerations;
using Core.Interfaces.Repositories;
using Core.ViewModels.Apis;
using Core.ViewModels.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
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

        public UserController(IUserRepository userRepository, IOptions<ApplicationSettings> appSettings)
        {
            repository = userRepository;
            settings = appSettings.Value;
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
            var user = new User()
            {
                City = model.City,
                Email = model.Email,
                LastName = model.LastName,
                Name = model.Name,
                Password = model.Password,
                Phone = model.Phone
            };

            // TODO: validate user

            await repository.AddAsync(user);
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
            string token = tokenHandler.WriteToken(securityToken);
            return Ok(new { token });
        }

        [HttpPost]
        [Route("SocialLogin")]
        public async Task<object> SocialLogin([FromBody] LoginModel model)
        {
            var user = await repository.GetUserByEmailAsync(model.Email);

            if (user is null || model.Password != user.Password)
            {
                return BadRequest(new { message = "Invalid username or password" });
            }

            if (await VerifyTokenAsync(model.IdToken))
            {
                var tokenDescriptor = new SecurityTokenDescriptor()
                {
                    Expires = DateTime.UtcNow.AddMinutes(5),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                return Ok(new { token }); 
            }

            return BadRequest(new { message = "Error loging in with google" });
        }

        private async Task<bool> VerifyTokenAsync(string providerToken)
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
                return false;
            }

            if (responseMessage.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return false;
            }

            var response = await responseMessage.Content.ReadAsStringAsync();
            var googleApiTokenInfo = JsonConvert.DeserializeObject<GoogleApiTokenInfo>(response);
            return true;
        }
    }
}