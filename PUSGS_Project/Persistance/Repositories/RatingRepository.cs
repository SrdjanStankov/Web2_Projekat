using Core.Entities;
using Core.Interfaces.Repositories;
using Core.ViewModels.Rating;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
	public class RatingRepository : IRatingRepository
	{
		private readonly ApplicationDbContext context;

		public RatingRepository(ApplicationDbContext context)
		{
			this.context = context;
		}

		public async Task<bool> AddAsync(RatingModel ratingModel)
		{
			var rating = await context.Rating.FirstOrDefaultAsync(item => item.Id == ratingModel.Id) ?? new Rating() { Value = ratingModel.Value };
			if (rating.Id != 0)
			{
				// ako je pronašao rating da vec postoji
				return false;
			}

			rating.RatingGiver = await context.User.FirstOrDefaultAsync(item => item.Email == ratingModel.UserId);
			rating.Car = await context.Car.FirstOrDefaultAsync(item => item.Id == ratingModel.CarId);
			if (rating.Car is object)
			{
				var carReservation = await context.CarReservations.FirstOrDefaultAsync(item => item.Id == ratingModel.ReservationId);
				carReservation.Rating = rating.Value; 
			}

			// ovde dodaješ pronalaženje dodatnih polja ako ih dodaš u rating model

			await context.Rating.AddAsync(rating);
			await context.SaveChangesAsync();
			return true;
		}
	}
}
