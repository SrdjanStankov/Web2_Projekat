using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces.Repositories
{
	public interface ICarReservationRepository
	{
        Task<CarReservation> GetReservationAsync(long id);

        Task<bool> AddCarReservationAsync(CarReservation reservation);

        Task DeleteAsync(long id);
	}
}
