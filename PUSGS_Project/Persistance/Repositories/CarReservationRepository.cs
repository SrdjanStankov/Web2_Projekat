using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
	public class CarReservationRepository : ICarReservationRepository
	{
		private readonly ApplicationDbContext context;

		public CarReservationRepository(ApplicationDbContext context)
		{
			this.context = context;
		}

		public async Task<bool> AddCarReservationAsync(CarReservation reservation)
		{
			var carReservation = await context.CarReservations.FirstOrDefaultAsync(item => item.Id == reservation.Id);
			if (carReservation is object)
			{
				return false;
			}
			var car = await context.Car.FirstOrDefaultAsync(item => item.Id == reservation.ReservedCarId);
			var user = await context.User.FirstOrDefaultAsync(item => item.Email == reservation.OwnerEmail);
			car.IsReserved = true;
			reservation.ReservedCar = car;
			reservation.Owner = user;
			await context.CarReservations.AddAsync(reservation);
			await context.SaveChangesAsync();
			return true;
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
