using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.ViewModels.CarViewModels;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly ApplicationDbContext context;

        public CarRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> AddAsync(Car car)
        {
            var c = await context.FindAsync<Car>(car.Id);
            if (c is object)
            {
                return false;
            }
            await context.AddAsync(car);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task DeleteAsync(long id)
        {
            var car = await context.Car.FindAsync(id);
            context.Car.Remove(car);
            await context.SaveChangesAsync();
        }

        public async Task<Car> GetAsync(long id)
        {
            return await context.FindAsync<Car>(id);
        }

        public async Task<double> GetAverageRatingAsync(long id)
        {
            var car = await GetAsync(id);
            return car.Ratings.DefaultIfEmpty(new Rating()).Average(rating => rating.Value);
        }

        public async Task<IEnumerable<Car>> GetCarsOfAgencyAsync(long rentACarId)
        {
            return (await context.RentACar.Include(r => r.Cars).FirstOrDefaultAsync(item => item.Id == rentACarId))?.Cars;
        }

        public bool IsReserved(Car car, DateTime takeDate, DateTime returnDate)
        {
            return car.ReservedFrom < returnDate && takeDate < car.ReservedTo;
        }

        public async Task<bool> ReserveCarAsync(long id, ReservationDateInterval interval)
        {
            var car = await GetAsync(id);

            if (IsReserved(car, interval.DateFrom, interval.DateTo))
            {
                return false;
            }

            car.ReservedFrom = interval.DateFrom;
            car.ReservedTo = interval.DateTo;
            await context.SaveChangesAsync();
            return true;
        }

        public async Task UpdateAsync(Car car)
        {
            context.Update(car);
            await context.SaveChangesAsync();
        }
    }
}
