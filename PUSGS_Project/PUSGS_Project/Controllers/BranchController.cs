using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PUSGS_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ApiController
    {
        private readonly IBranchRepository repository;

        public BranchController(IBranchRepository branchRepository, IUserRepository userRepository) : base(userRepository)
        {
            repository = branchRepository;
        }

        // GET: api/Branch
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/Branch/5
        [HttpGet("{id}")]
        public async Task<Branch> GetAsync(int id)
        {
            return await repository.GetAsync(id);
        }

        // POST: api/Branch
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<object> PostAsync([FromBody] Branch model)
        {
            var user = await GetLoginUserAsync();

            if (user is RentACarAdministrator)
            {
                if (!await repository.AddAsync(model))
                {
                    return BadRequest(new { message = "Already exist" });
                }
                return Ok(model); 
            }

            return Forbid();
        }

        // PUT: api/Branch/5
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<object> PutAsync(int id, [FromBody] Branch value)
        {
            var user = await GetLoginUserAsync();

            if (user is RentACarAdministrator)
            {
                await repository.UpdateAsync(value);
                return Ok();
            }

            return Forbid();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<object> DeleteAsync(int id)
        {
            var user = await GetLoginUserAsync();
            
            if (user is RentACarAdministrator)
            {
                await repository.DeleteAsync(id);
                return Ok();
            }

            return Forbid();
        }
    }
}
