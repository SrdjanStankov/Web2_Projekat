using Core.Entities;
using Core.ViewModels.Rating;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
	public interface IRatingRepository
	{
		Task<bool> AddAsync(RatingModel rating);
	}
}
