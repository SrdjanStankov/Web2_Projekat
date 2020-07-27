using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.ViewModels.Rating;
using Microsoft.EntityFrameworkCore;

namespace Persistance.RentACar.Repositories
{
    public class RatingRepository : IRatingRepository
    {
        private readonly RentACarDbContext context;

        public RatingRepository(RentACarDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> AddAsync(RatingModel ratingModel)
        {
            var rating = await context.Ratings.FirstOrDefaultAsync(item => item.Id == ratingModel.Id) ?? new Rating() { Value = ratingModel.Value };
            if (rating.Id != 0)
            {
                // ako je pronašao rating da vec postoji
                return false;
            }

            rating.RatingGiverEmail = ratingModel.UserId;
            rating.CarId = ratingModel.CarId;
            if (rating.CarId != 0)
            {
                var carReservation = await context.CarReservations.FirstOrDefaultAsync(item => item.Id == ratingModel.ReservationId);
                carReservation.Rating = rating.Value;
            }

            // ovde dodaješ pronalaženje dodatnih polja ako ih dodaš u rating model

            await context.Ratings.AddAsync(rating);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
