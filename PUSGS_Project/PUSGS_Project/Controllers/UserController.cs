using Core.Entities;
using Core.Enumerations;
using Core.Interfaces.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
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
        public Task<List<User>> Get()
        {
            return repository.GetUsersAsync();
        }

        // GET: api/User/5
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("{id}", Name = "Get")]
        public Task<User> Get(string id)
        {
            return repository.GetUserByEmailAsync(id);
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
    }
}