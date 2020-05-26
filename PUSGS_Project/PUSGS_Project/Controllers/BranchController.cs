using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace PUSGS_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : Controller
    {
        private readonly IBranchRepository repository;

        public BranchController(IBranchRepository branchRepository)
        {
            repository = branchRepository;
        }

        // GET: api/Branch
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Branch/5
        [HttpGet("{id}")]
        public async Task<Branch> GetAsync(int id)
        {
            return await repository.GetAsync(id);
        }

        // POST: api/Branch
        [HttpPost]
        public async Task<object> PostAsync([FromBody] Branch model)
        {
            if (!await repository.AddAsync(model))
            {
                return BadRequest(new { message = "Already exist" });
            }
            return Ok(model);
        }

        // PUT: api/Branch/5
        [HttpPut("{id}")]
        public async Task PutAsync(int id, [FromBody] Branch value)
        {
            await repository.UpdateAsync(value);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            await repository.DeleteAsync(id);
        }
    }
}
