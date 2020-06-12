using Core.Entities;
using Core.ViewModels.Aviation;
using Core.ViewModels.Aviation.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface IFlightService
    {
        Task<long> AddAsync(AddFlightRequestModel company);

        Task<List<FlightModel>> GetAllAsync();

        Task<FlightModel> GetByIdAsync(long id);

        Task RemoveAsync(long id);

        Task<long> MakeReservationAsync(FlightTicketModel model);

        Task MakeFriendReservations(IEnumerable<FlightTicketModel> models);

        Task<List<FlightTicketDetailsModel>> GetFlightTicketHistoryForUserAsync(string userEmail);

        Task UpdateAsync(long id, UpdateFlightRequestModel model);

        Task CancelReservationAsync(long id);

        Task AcceptReservationAsync(long id);

        Task MakeQuickReservationAsync(QuickReservationRequestModel model);

        Task CancelQuickReservationAsync(long ticketId);
        Task RateAsync(RateFlightRequestModel model);
    }
}