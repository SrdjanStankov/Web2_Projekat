using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Interfaces.Repositories;
using Core.ViewModels.Rating;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PUSGS_Project.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RatingController : ApiController
	{
		private readonly IRatingRepository ratingRepository;
		public RatingController(IUserRepository userRepository, IRatingRepository ratingRepository) : base(userRepository)
		{
			this.ratingRepository = ratingRepository;
		}

		// GET: api/<RatingController>
		//[HttpGet]
		//public IEnumerable<string> Get()
		//{
		//	return new string[] { "value1", "value2" };
		//}

		// GET api/<RatingController>/5
		//[HttpGet("{id}")]
		//public string Get(int id)
		//{
		//	return "value";
		//}

		// POST api/<RatingController>
		[HttpPost]
		public async Task<object> Post([FromBody] RatingModel value)
		{
			await ratingRepository.AddAsync(value);
			return Ok();
		}

		// PUT api/<RatingController>/5
		//[HttpPut("{id}")]
		//public void Put(int id, [FromBody] string value)
		//{
		//}

		// DELETE api/<RatingController>/5
		//[HttpDelete("{id}")]
		//public void Delete(int id)
		//{
		//}
	}
}
