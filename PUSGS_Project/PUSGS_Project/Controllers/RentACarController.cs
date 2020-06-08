using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Enumerations;
using Core.Interfaces.Repositories;
using Core.ViewModels.CarViewModels;
using Core.ViewModels.RentACar;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PUSGS_Project.Controllers
{
    [Route("api/[controller]")]
    public class RentACarController : ApiController
    {
        private readonly IRentACarRepository repository;

        public RentACarController(IRentACarRepository repository, IUserRepository userRepository) : base(userRepository)
        {
            this.repository = repository;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<IEnumerable<RentACarModel>> GetAsync()
        {
			return new HashSet<RentACarModel>((await repository.GetAllAsync()).Select(s => new RentACarModel(s)));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<RentACarModel> GetAsync(int id)
        {
			return new RentACarModel(await repository.GetAsync(id));
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<object> Post([FromBody]RentACar model)
        {
            var user = await GetLoginUserAsync();

            if (user is SystemAdministrator)
            {
                var rentacar = new RentACar()
                {
                    Address = model.Address,
                    Description = model.Description,
                    Name = model.Name
                };

                if (!await repository.AddAsync(rentacar))
                {
                    return BadRequest(new { message = "Already exist" });
                }
                return Ok();
            }
            
            return Forbid();
        }

        [HttpPost]
        [Route("AddCar")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<object> AddCar([FromBody] CarRentACarModel model)
        {
            var user = await GetLoginUserAsync();

            if (user is RentACarAdministrator)
            {
                await repository.AddCarToAgencyAsync(model.CarId, model.RentACarId);
                return Ok();
            }

            return Forbid();
        }

        [HttpPost]
        [Route("AddBranch")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<object> AddBranch([FromBody] BranchModel model)
        {
            var user = await GetLoginUserAsync();
            if (user is RentACarAdministrator)
            {
                await repository.AddBranchToAgencyAsync(model.BranchId, model.RentACarId);
                return Ok();
            }

            return Forbid();
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<object> Put(int id, [FromBody]RentACar model)
        {
            var user = await GetLoginUserAsync();

            if (user is RentACarAdministrator)
            {
                await repository.UpdateAsync(model);
                return Ok();
            }

            return Forbid();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<object> Delete(int id)
        {
            var user = await GetLoginUserAsync();

            if (user is SystemAdministrator)
            {
                await repository.Delete(id);
                return Ok();
            }

            return Forbid();
        }
    }
}
