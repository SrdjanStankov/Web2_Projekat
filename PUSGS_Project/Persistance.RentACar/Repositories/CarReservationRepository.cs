using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistance.RentACar.Repositories
{
    public class CarReservationRepository : ICarReservationRepository
    {
        private readonly RentACarDbContext context;

        public CarReservationRepository(RentACarDbContext context)
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
            var car = await context.Cars.FirstOrDefaultAsync(item => item.Id == reservation.ReservedCarId);
            //var user = await context.User.FirstOrDefaultAsync(item => item.Email == reservation.OwnerEmail);
            car.IsReserved = true;
            if (reservation.Discount > 0)
            {
                var costPerDay = (reservation.To - reservation.From).Value.TotalDays * car.CostPerDay;
                reservation.CostForRange = costPerDay - (costPerDay * (reservation.Discount / 100));
            }
            reservation.ReservedCar = car;
            //reservation.Owner = user;
            await context.CarReservations.AddAsync(reservation);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<CarReservation>> GetReservationAsync(long rentACarAgencyId) => await context.CarReservations.Include(r => r.ReservedCar).ThenInclude(c => c.RentACar).Where(r => r.ReservedCar.RentACarId == rentACarAgencyId).ToListAsync();

        public async Task<IEnumerable<CarReservation>> GetReservationsAsync(string userEmail) => await context.CarReservations.Where(item => item.OwnerEmail == userEmail).ToListAsync();

        public async Task UpdateReservationAsync(CarReservation reservation)
        {
            context.CarReservations.Update(reservation);
            await context.SaveChangesAsync();
        }
    }
}
