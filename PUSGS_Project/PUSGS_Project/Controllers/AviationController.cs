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
    public class AviationController : ControllerBase
    {
        private readonly IAviationService _aviationService;

        public AviationController(IAviationService aviationService)
        {
            _aviationService = aviationService;
        }

        // GET: api/<controller>
        [HttpGet]
        public Task<List<AviationCompanyModel>> Get()
        {
            return _aviationService.GetAllCompaniesAsync();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<object> Get(int id)
        {
            var company = await _aviationService.GetCompanyByIdAsync(id);
            if (company is null)
            {
                return NotFound();
            }
            return new OkObjectResult(company);
        }

        // POST api/<controller>
        [HttpPost]
        public Task<long> Post([FromBody]AddOrUpdateAviationCompanyRequestModel model)
        {
            return _aviationService.AddAviationCompanyAsync(model);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public Task Put(long id, [FromBody]AddOrUpdateAviationCompanyRequestModel model)
        {
            model.Id = id;
            return _aviationService.UpdateAviationCompanyAsync(model);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public Task Delete(long id)
        {
            return _aviationService.DeleteAviationCompanyAsync(id);
        }
    }
}