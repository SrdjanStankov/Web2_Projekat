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

        Task<long> MakeReservation(FlightTicketModel model);

        Task MakeFriendReservations(IEnumerable<FlightTicketModel> models);

        Task<List<FlightTicketDetailsModel>> GetFlightTicketHistoryForUser(string userEmail);
        Task UpdateAsync(int id, UpdateFlightRequestModel model);
    }
}