using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.ViewModels.CarViewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PUSGS_Project.Api.RentACars.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ApiController
    {
        private readonly ICarRepository carRepository;

        public CarController(ICarRepository carRepository, IUserRepository userRepository) : base(userRepository)
        {
            this.carRepository = carRepository;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<Car> GetAsync(long id) => await carRepository.GetAsync(id);

        // GET api/<controller>/RentACar/5
        [HttpGet]
        [Route("RentACar/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<object> GetCarsAsync(long id, [FromQuery] CarReservationModel model, [FromQuery] bool all)
        {
            var user = await GetLoginUserAsync();

            if (user is User)
            {
                var carsModel = new List<CarReservationDetailsModel>();

                foreach (var item in await carRepository.GetCarsOfAgencyAsync(id))
                {
                    if (!all)
                    {
                        if (item.PassengerNumber != model.PassengerNumber || model.MaxCost < item.CostPerDay || model.Type != item.Type || item.IsReserved)
                        {
                            continue;
                        }
                    }
                    if (all && item.IsReserved)
                    {
                        continue;
                    }
                    carsModel.Add(new CarReservationDetailsModel(item)
                    {
                        AverageRating = await carRepository.GetAverageRatingAsync(item.Id),
                        CostForRange = (model.ReturnDate - model.TakeDate).Value.TotalDays * item.CostPerDay
                    });
                }

                return carsModel;
            }
            else
            {
                return Forbid();
            }
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
                if ((await carRepository.GetAsync(value.Id)).IsReserved)
                {
                    return BadRequest(new { message = "Unable to change reserved car!" });
                }
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
                if ((await carRepository.GetAsync(id)).IsReserved)
                {
                    return BadRequest(new { message = "Unable to remove reserved car!" });
                }
                await carRepository.DeleteAsync(id);
                return Ok();
            }

            return Forbid();
        }
    }
}
