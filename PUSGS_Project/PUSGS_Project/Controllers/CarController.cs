using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.ViewModels.CarViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PUSGS_Project.Controllers
{
    [Route("api/[controller]")]
    public class CarController : Controller
    {
        private readonly ICarRepository repository;

        public CarController(ICarRepository carRepository)
        {
            repository = carRepository;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get() => new string[] { "value1", "value2" };

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<Car> GetAsync(long id)
        {
            return await repository.GetAsync(id);
        }

        // GET api/<controller>/RentACar/5
        [HttpGet]
        [Route("RentACar/{id}")]
        public async Task<IEnumerable<CarReservationDetailsModel>> GetCarsAsync(long id, [FromQuery] CarReservationModel model)
        {
            var carsModel = new List<CarReservationDetailsModel>();

            foreach (var item in await repository.GetCarsOfAgencyAsync(id))
            {
                if (item.PassengerNumber != model.PassengerNumber || model.MaxCost < item.CostPerDay || model.Type != item.Type || repository.IsReserved(item, model.TakeDate, model.ReturnDate))
                {
                    continue;
                }
                carsModel.Add(new CarReservationDetailsModel(item)
                {
                    AverageRating = await repository.GetAverageRatingAsync(item.Id),
                    CostForRange = (model.ReturnDate - model.TakeDate).TotalDays * item.CostPerDay
                });
            }

            return carsModel;
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<object> PostAsync([FromBody] Car model)
        {
            if (!await repository.AddAsync(model))
            {
                return BadRequest(new { message = "Already exist" });
            }
            return Ok(model);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Car value)
        {
            await repository.UpdateAsync(value);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await repository.DeleteAsync(id);
        }

        [HttpPost]
        [Route("Reserve/{id}")]
        public async Task<object> ReserveCarAsync(long id, [FromBody] ReservationDateInterval interval)
        {
            if(!await repository.ReserveCarAsync(id, interval))
            {
                return BadRequest(new { message = "Already taken" });
            }
            return Ok();
        }
    }
}
