using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.ViewModels.Aviation;
using Core.ViewModels.Aviation.Requests;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Services
{
    public class FlightService : IFlightService
    {
        private readonly IFlightRepository _flightRepository;
        private readonly IAviationRepository _aviationRepository;
        private readonly IFlightSeatRepository _seatRepository;
        private readonly IFlightTicketRepository _ticketRepository;

        public FlightService(
            IFlightRepository flightRepository,
            IAviationRepository aviationRepository,
            IFlightSeatRepository seatRepository,
            IFlightTicketRepository ticketRepository)
        {
            _flightRepository = flightRepository;
            _aviationRepository = aviationRepository;
            _seatRepository = seatRepository;
            _ticketRepository = ticketRepository;
        }

        public async Task<long> AddAsync(AddFlightRequestModel company)
        {
            var aviation = await _aviationRepository.GetByIdAsync(company.AviationCompanyId);
            if (aviation == null)
            {
                throw new KeyNotFoundException($"AviationCompany with Id='{company.AviationCompanyId}' could not be found!");
            }

            var flight = MapToFlight(company, aviation);

            long flightId = await _flightRepository.AddAsync(flight);

            await AddSeatsAsync(flightId, company.NumberOfSeats);

            return flightId;
        }

        private Task AddSeatsAsync(long flightId, int numberOfSeats)
        {
            var seats = new List<FlightSeat>();
            for (int i = 0; i < numberOfSeats; ++i)
            {
                seats.Add(new FlightSeat
                {
                    FlightId = flightId,
                    SeatNumber = i
                });
            }
            return _seatRepository.AddRangeAsync(seats);
        }

        private static Flight MapToFlight(AddFlightRequestModel company, AviationCompany aviation)
        {
            return new Flight
            {
                AviationCompanyId = aviation.Id,
                ArrivalTime = company.ArrivalTime,
                DepartureTime = company.DepartureTime,
                TicketPrice = company.TicketPrice,
                TravelLength = company.TravelLength,
                NumberOfChangeovers = company.NumberOfChangeovers,
                From = company.From.ToLocation(),
                To = company.To.ToLocation()
            };
        }

        public async Task<List<FlightModel>> GetAllAsync()
        {
            var flights = await _flightRepository.GetAllAsync();
            return flights.Select(f => new FlightModel(f)).ToList();
        }

        public async Task<FlightModel> GetByIdAsync(long id)
        {
            var flight = await _flightRepository.GetByIdAsync(id);
            return new FlightModel(flight);
        }

        public Task UpdateAsync(long id, UpdateFlightRequestModel model)
        {
            return _flightRepository.UpdateAsync(id, model);
        }

        public Task RemoveAsync(long id)
        {
            return _flightRepository.RemoveAsync(id);
        }

        public Task<long> MakeReservationAsync(FlightTicketModel model)
        {
            var ticket = MapToTicket(model, accepted: true);
            return _ticketRepository.AddAsync(ticket);
        }

        public Task MakeFriendReservations(IEnumerable<FlightTicketModel> models)
        {
            var tickets = models.Select(m => MapToTicket(m, accepted: false));
            return _ticketRepository.AddRangeAsync(tickets);
        }

        private static FlightTicket MapToTicket(FlightTicketModel model, bool accepted = true)
        {
            return new FlightTicket
            {
                FlightId = model.FlightId,
                FlightSeatId = model.FlightSeatId,
                TicketOwnerEmail = model.TicketOwnerEmail,
                Discount = model.Discount,
                Accepted = accepted
            };
        }

        public async Task<List<FlightTicketDetailsModel>> GetFlightTicketHistoryForUserAsync(string userEmail)
        {
            var tickets = await _ticketRepository.GetDetailedTicketsByOwnerEmailAsync(userEmail);
            return tickets.Select(t => new FlightTicketDetailsModel(t)).ToList();
        }

        public Task CancelReservationAsync(long id)
        {
            return _ticketRepository.RemoveAsync(id);
        }

        public Task AcceptReservationAsync(long id)
        {
            return _ticketRepository.AcceptAsync(id);
        }

        public async Task MakeQuickReservationAsync(QuickReservationRequestModel model)
        {
            var flightTicket = await _ticketRepository.GetByIdAsync(model.FlightTicketId);
            flightTicket.TicketOwnerEmail = model.UserEmail;
            await _ticketRepository.UpdateAsync(flightTicket);
        }

        public async Task CancelQuickReservationAsync(long ticketId)
        {
            var flightTicket = await _ticketRepository.GetByIdAsync(ticketId);
            flightTicket.TicketOwnerEmail = null;
            await _ticketRepository.UpdateAsync(flightTicket);
        }

        public async Task RateAsync(RateFlightRequestModel model)
        {
            var ticket = await _ticketRepository.GetByIdAsync(model.FlightTicketId);
            ticket.Rating = model.Rating;
            await _ticketRepository.UpdateAsync(ticket);
        }
    }
}