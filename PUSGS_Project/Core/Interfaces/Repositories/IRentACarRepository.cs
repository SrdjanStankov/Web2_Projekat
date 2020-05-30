using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface IRentACarRepository
    {
        RentACar Get(long id);

        IEnumerable<RentACar> GetAll();

        Task<bool> AddAsync(RentACar rentACar);

        Task Delete(long id);

        Task UpdateAsync(RentACar rentACar);
        
        Task AddCarToAgencyAsync(long carId, long rentACarId);

        Task AddBranchToAgencyAsync(long branchId, long rentACarId);

        double GetAverageRating(long id);
    }
}
