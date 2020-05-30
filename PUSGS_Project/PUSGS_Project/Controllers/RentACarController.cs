using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Enumerations;
using Core.Interfaces.Repositories;
using Core.ViewModels.RentACar;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PUSGS_Project.Controllers
{
    [Route("api/[controller]")]
    public class RentACarController : Controller
    {
        private readonly IRentACarRepository repository;
        private readonly IUserRepository userRepository;

        public RentACarController(IRentACarRepository repository, IUserRepository userRepository)
        {
            this.repository = repository;
            this.userRepository = userRepository;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<IEnumerable<RentACarModel>> GetAsync()
        {
            var hashSet = new HashSet<RentACarModel>();

            foreach (var item in (await repository.GetAllAsync()).Select(async s =>
            {
                return new RentACarModel(s)
                {
                    AverageRating = await repository.GetAverageRatingAsync(s.Id)
                };
            }))
            {
                hashSet.Add(await item);
            }

            return hashSet;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<RentACarModel> GetAsync(int id)
        {
            var rentACar = await repository.GetAsync(id);
            var rentACarModel = new RentACarModel(rentACar)
            {
                AverageRating = await repository.GetAverageRatingAsync(id)
            };
            return rentACarModel;
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<object> Post([FromBody]RentACar model)
        {
            var userEmail = User.Claims.FirstOrDefault(item => item.Type == AppConsts.CLAIM_TOKEN_KEY)?.Value;
            var user = await userRepository.GetUserByEmailAsync(userEmail);

            if (user is SystemAdministrator)
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
            else
            {
                return Forbid();
            }
        }

        [HttpPost]
        [Route("AddCar")]
        public async Task<object> AddCar([FromBody] CarModel model)
        {
            await repository.AddCarToAgencyAsync(model.CarId, model.RentACarId);
            return Ok();
        }

        [HttpPost]
        [Route("AddBranch")]
        public async Task<object> AddBranch([FromBody] BranchModel model)
        {
            await repository.AddBranchToAgencyAsync(model.BranchId, model.RentACarId);
            return Ok();
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<object> Put(int id, [FromBody]RentACar model)
        {
            await repository.UpdateAsync(model);
            return Ok();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
