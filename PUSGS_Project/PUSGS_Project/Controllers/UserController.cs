using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace PUSGS_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository repository;

        public UserController(IUserRepository userRepository)
        {
            repository = userRepository;
        }

        // GET: api/User
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/User
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpPost]
        [Route("Register")]
        public async Task<object> Post([FromBody] User model)
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

            // TODO: make repository async
            repository.Add(user);
            return Ok();
        }
    }
}
