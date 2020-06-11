using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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

		// GET api/<CarReservationController>/5
		[HttpGet("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
		public async Task<object> Get(string id)
		{
			var user = await GetLoginUserAsync();

			if (user is User)
			{
				return await carReservationRepository.GetReservationsAsync(id); 
			}
			else
			{
				return Forbid();
			}
		}

		// POST api/<CarReservationController>
		[HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
		public async Task<object> Post([FromBody] CarReservation reservation)
		{
			var user = await GetLoginUserAsync();

			if (user is User)
			{
				if (!await carReservationRepository.AddCarReservationAsync(reservation))
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
	}
}
