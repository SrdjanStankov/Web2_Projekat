using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PUSGS_Project.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CarReservationController : ApiController
	{
		private readonly ICarReservationRepository carReservationRepository;

		public CarReservationController(ICarReservationRepository carReservationRepository, IUserRepository userRepository) : base(userRepository)
		{
			this.carReservationRepository = carReservationRepository;
		}

		// GET: api/<CarReservationController>
		//[HttpGet]
		//public IEnumerable<string> Get()
		//{
		//	return new string[] { "value1", "value2" };
		//}

		// GET api/<CarReservationController>/5
		[HttpGet("{id}")]
		public async Task<IEnumerable<CarReservation>> Get(string id)
		{
			return await carReservationRepository.GetReservationsAsync(id);
		}

		// POST api/<CarReservationController>
		[HttpPost]
		public async Task<object> Post([FromBody] CarReservation reservation)
		{
			if(!await carReservationRepository.AddCarReservationAsync(reservation))
			{
				return BadRequest(new { message = "Already exist" });
			}
			return Ok();
		}

		// PUT api/<CarReservationController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<CarReservationController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
