using Core.Interfaces.Services;
using Core.ViewModels.Aviation;
using Core.ViewModels.Aviation.Requests;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PUSGS_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly IFlightService _flightService;

        public FlightController(IFlightService flightService)
        {
            _flightService = flightService;
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public Task Delete(long id)
        {
            return _flightService.RemoveAsync(id);
        }

        // GET: api/<controller>
        [HttpGet]
        public Task<List<FlightModel>> Get()
        {
            return _flightService.GetAllAsync();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<object> Get(int id)
        {
            var flightModel = await _flightService.GetByIdAsync(id);
            if (flightModel is null)
            {
                return NotFound();
            }
            return new OkObjectResult(flightModel);
        }

        // POST api/<controller>
        [HttpPost]
        public Task<long> Post([FromBody]AddFlightRequestModel model)
        {
            return _flightService.AddAsync(model);
        }
    }
}