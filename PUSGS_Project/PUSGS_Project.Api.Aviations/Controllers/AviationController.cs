﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.ViewModels.Aviation;
using Core.ViewModels.Aviation.Requests;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PUSGS_Project.Api.Aviations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AviationController : ControllerBase
    {
        private readonly IAviationService _aviationService;
        private readonly IFlightTicketRepository _ticketRepository;

        public AviationController(IAviationService aviationService, IFlightTicketRepository ticketRepository)
        {
            _aviationService = aviationService;
            _ticketRepository = ticketRepository;
        }

        // GET: api/<controller>
        [HttpGet]
        public Task<List<AviationCompanyModel>> Get() => _aviationService.GetAllCompaniesAsync();

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
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public Task<long> Post([FromBody] AddOrUpdateAviationCompanyRequestModel model) => _aviationService.AddAviationCompanyAsync(model);

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public Task Put(long id, [FromBody] AddOrUpdateAviationCompanyRequestModel model)
        {
            model.Id = id;
            return _aviationService.UpdateAviationCompanyAsync(model);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public Task Delete(long id) => _aviationService.DeleteAviationCompanyAsync(id);

        [HttpGet("{id}/quick-reservations")]
        public async Task<List<FlightTicketDetailsModel>> GetTickets(long id)
        {
            var tickets = await _ticketRepository.GetAllByAviationIdAsync(id);
            return tickets.Where(t => t.TicketOwnerEmail == null).Select(t => new FlightTicketDetailsModel(t)).ToList();
        }
    }
}
