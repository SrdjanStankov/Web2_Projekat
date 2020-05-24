using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PUSGS_Project.Controllers
{
    [Route("api/[controller]")]
    public class RentACarController : Controller
    {
        private readonly IRentACarRepository repository;

        public RentACarController(IRentACarRepository repository)
        {
            this.repository = repository;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<RentACar> Get() => repository.GetAll();

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public RentACar Get(int id) => repository.Get(id);

        // POST api/<controller>
        [HttpPost]
        public async Task<object> Post([FromBody]RentACar model)
        {
            var rentacar = new RentACar()
            {
                Address = model.Address,
                Description = model.Description,
                Name = model.Name
            };

            // TODO: validate RentACar

            if (!await repository.AddAsync(rentacar))
            {
                return BadRequest(new { message = "Already exist" });
            }
            return Ok();
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
