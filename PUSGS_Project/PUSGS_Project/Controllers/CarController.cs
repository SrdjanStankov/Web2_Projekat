using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.ViewModels.CarViewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PUSGS_Project.Controllers
{
    [Route("api/[controller]")]
    public class CarController : ApiController
    {
        private readonly ICarRepository carRepository;

        public CarController(ICarRepository carRepository, IUserRepository userRepository) : base(userRepository)
        {
            this.carRepository = carRepository;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<Car> GetAsync(long id)
        {
            return await carRepository.GetAsync(id);
        }

        // GET api/<controller>/RentACar/5
        [HttpGet]
        [Route("RentACar/{id}")]
        public async Task<IEnumerable<CarReservationDetailsModel>> GetCarsAsync(long id, [FromQuery] CarReservationModel model)
        {
            var carsModel = new List<CarReservationDetailsModel>();

            foreach (var item in await carRepository.GetCarsOfAgencyAsync(id))
            {
                if (item.PassengerNumber != model.PassengerNumber || model.MaxCost < item.CostPerDay || model.Type != item.Type || item.IsReserved)
                {
                    continue;
                }
                carsModel.Add(new CarReservationDetailsModel(item)
                {
                    AverageRating = await carRepository.GetAverageRatingAsync(item.Id),
                    CostForRange = (model.ReturnDate - model.TakeDate).TotalDays * item.CostPerDay
                });
            }

            return carsModel;
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<object> PostAsync([FromBody] Car model)
        {
            var user = await GetLoginUserAsync();

            if (user is RentACarAdministrator)
            {
                if (!await carRepository.AddAsync(model))
                {
                    return BadRequest(new { message = "Already exist" });
                }
                return Ok(model);
            }

            return Forbid();

        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<object> Put(int id, [FromBody] Car value)
        {
            var user = await GetLoginUserAsync();

            if (user is RentACarAdministrator)
            {
                await carRepository.UpdateAsync(value);
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

            if (user is RentACarAdministrator)
            {
                await carRepository.DeleteAsync(id);
                return Ok();
            }

            return Forbid();
        }
    }
}
