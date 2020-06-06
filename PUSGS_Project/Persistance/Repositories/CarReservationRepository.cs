using Core.Entities;
using Core.Interfaces.Repositories;
using System;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
	public class CarReservationRepository : ICarReservationRepository
	{
		public Task<bool> AddCarReservationAsync(CarReservation reservation)
		{
			throw new NotImplementedException();
		}

		public Task DeleteAsync(long id)
		{
			throw new NotImplementedException();
		}

		public Task<CarReservation> GetReservationAsync(long id)
		{
			throw new NotImplementedException();
		}
	}
}
