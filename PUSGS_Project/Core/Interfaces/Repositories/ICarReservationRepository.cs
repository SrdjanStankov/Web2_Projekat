using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces.Repositories
{
	public interface ICarReservationRepository
	{
        Task<IEnumerable<CarReservation>> GetReservationAsync(long rentACarAgencyId);

        Task<IEnumerable<CarReservation>> GetReservationsAsync(string userEmail);

        Task<bool> AddCarReservationAsync(CarReservation reservation);
		
		Task UpdateReservationAsync(CarReservation reservation);
	}
}
