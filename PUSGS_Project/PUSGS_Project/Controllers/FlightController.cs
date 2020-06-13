using Core.Entities;
using Core.Interfaces.Services;
using Core.ViewModels.Aviation;
using Core.ViewModels.Aviation.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PUSGS_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly IFlightService _flightService;
        private readonly IEmailService _emailService;
        private readonly ApplicationSettings _settings;

        public FlightController(IFlightService flightService, IEmailService emailService, IOptions<ApplicationSettings> options)
        {
            _flightService = flightService;
            _emailService = emailService;
            _settings = options.Value;
        }

        #region flight

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
        public async Task<object> Get(long id)
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

        [HttpPut("{id}")]
        public Task Put(long id, [FromBody] UpdateFlightRequestModel model)
        {
            return _flightService.UpdateAsync(id, model);
        }

        #endregion flight

        #region tickets

        [HttpGet("ticket/{id}/accept")]
        public Task AcceptReservation(long id)
        {
            return _flightService.AcceptReservationAsync(id);
        }

        [HttpDelete("ticket/{id}")]
        public Task CancelReservation(long id)
        {
            return _flightService.CancelReservationAsync(id);
        }

        [HttpPost("ticket")]
        public Task<long> MakeReservation([FromBody]FlightTicketModel model)
        {
            // TODO: Send confirmation mail that reservation has been made
            return _flightService.MakeReservationAsync(model);
        }

        [HttpPost("ticket-invitation")]
        public async Task InviteFriends([FromBody]InviteFriendsRequestModel request)
        {
            var friendTickets = await _flightService.MakeFriendReservations(request.FlightTickets);
            var tasks = friendTickets.Select(SendInvitationAsync).ToArray();
            await Task.WhenAll(tasks).ConfigureAwait(false);
        }

        private Task SendInvitationAsync(FlightTicket ticket)
        {
            var email = ticket.TicketOwnerEmail;
            string href = $"{_settings.Client_URL}/flight-ticket/{ticket.Id}/accept";
            string body = $"<p>For: {email}</p><a href=\"{href}\">Accept invitation</a>";
            return _emailService.SendMailAsync(email, "Flight Ticket Invitation request", body);
        }

        [HttpPost("quick-reservation")]
        public Task MakeQuickReservation([FromBody]QuickReservationRequestModel model)
        {
            return _flightService.MakeQuickReservationAsync(model);
        }

        [HttpDelete("quick-reservation/{id}")]
        public Task CancelQuickReservation(long id)
        {
            return _flightService.CancelQuickReservationAsync(id);
        }

        [HttpPost("rate")]
        public Task RateFlight([FromBody]RateFlightRequestModel model)
        {
            return _flightService.RateAsync(model);
        }

        #endregion tickets
    }
}