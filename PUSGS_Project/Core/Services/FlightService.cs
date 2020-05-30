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

        public FlightService(IFlightRepository flightRepository, IAviationRepository aviationRepository)
        {
            _flightRepository = flightRepository;
            _aviationRepository = aviationRepository;
        }

        public async Task<long> AddAsync(AddFlightRequestModel company)
        {
            var aviation = await _aviationRepository.GetByIdAsync(company.AviationCompanyId);
            if (aviation == null)
            {
                throw new KeyNotFoundException($"AviationCompany with Id='{company.AviationCompanyId}' could not be found!");
            }

            var flight = new Flight
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

            return await _flightRepository.AddAsync(flight);
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

        public Task RemoveAsync(long id)
        {
            return _flightRepository.RemoveAsync(id);
        }
    }
}