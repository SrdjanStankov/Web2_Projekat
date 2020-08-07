using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.ViewModels.Aviation;
using Core.ViewModels.Aviation.Requests;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace PUSGS_Project.Api.Aviations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ApiController
    {
        private readonly IFlightService _flightService;
        private readonly IEmailService _emailService;
        private readonly ApplicationSettings _settings;

        public FlightController(IFlightService flightService, IEmailService emailService, IOptions<ApplicationSettings> options, IUserRepository userRepository): base(userRepository)
        {
            _flightService = flightService;
            _emailService = emailService;
            _settings = options.Value;
        }

        #region flight

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public Task<long> Post([FromBody] AddFlightRequestModel model)
        {
            return _flightService.AddAsync(model);
        }

        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public Task Put(long id, [FromBody] UpdateFlightRequestModel model)
        {
            return _flightService.UpdateAsync(id, model);
        }

        [HttpGet]
        [Route("{id}/flight-history")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<object> GetFlightTicketHistory(string id)
        {
            var currUser = await GetLoginUserAsync();
            if (currUser.Email != id)
            {
                return Forbid();
            }

            var ticketHistory = await _flightService.GetFlightTicketHistoryForUserAsync(id);
            return Ok(ticketHistory);
        }

        #endregion flight

        #region tickets

        [HttpGet("ticket/{id}/accept")]
        public Task AcceptReservation(long id)
        {
            return _flightService.AcceptReservationAsync(id);
        }

        [HttpDelete("ticket/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public Task CancelReservation(long id)
        {
            return _flightService.CancelReservationAsync(id);
        }

        [HttpPost("ticket")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<long> MakeReservation([FromBody] FlightTicketModel model)
        {
            var ticketId = await _flightService.MakeReservationAsync(model);

            if (!string.IsNullOrWhiteSpace(model.TicketOwnerEmail) && _settings.SendEmailNotifications)
            {
                model.Id = ticketId;
                await SendTicketSuccessNotificationAsync(model.TicketOwnerEmail, model);
            }
            return ticketId;
        }

        private Task SendTicketSuccessNotificationAsync(string email, FlightTicketModel ticket)
        {
            string body = $"<p>For: {email}</p>"
                + $"<p>flightId: {ticket.FlightId}, ticketId: {ticket.Id}, Discount: {ticket.Discount}%</p>";
            return _emailService.SendMailAsync(email, "Reservation success", body);
        }

        [HttpPost("ticket-invitation")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task InviteFriends([FromBody] InviteFriendsRequestModel request)
        {
            var friendTickets = await _flightService.MakeFriendReservations(request.FlightTickets);

            if (_settings.SendEmailNotifications)
            {
                var tasks = friendTickets.Select(SendInvitationAsync).ToArray();
                await Task.WhenAll(tasks).ConfigureAwait(false);
            }
        }

        private Task SendInvitationAsync(FlightTicket ticket)
        {
            var email = ticket.TicketOwnerEmail;
            string href = $"{_settings.Client_URL}/flight-ticket/{ticket.Id}/accept";
            string body = $"<p>For: {email}</p><a href=\"{href}\">Accept invitation</a>";
            return _emailService.SendMailAsync(email, "Flight Ticket Invitation request", body);
        }

        [HttpPost("quick-reservation")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public Task MakeQuickReservation([FromBody] QuickReservationRequestModel model)
        {
            return _flightService.MakeQuickReservationAsync(model);
        }

        [HttpDelete("quick-reservation/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public Task CancelQuickReservation(long id)
        {
            return _flightService.CancelQuickReservationAsync(id);
        }

        [HttpPost("rate")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public Task RateFlight([FromBody] RateFlightRequestModel model)
        {
            return _flightService.RateAsync(model);
        }

        #endregion tickets
    }
}
