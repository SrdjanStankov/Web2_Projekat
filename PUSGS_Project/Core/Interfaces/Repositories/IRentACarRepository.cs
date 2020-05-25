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

        void Delete(long id);

        void Update(RentACar rentACar);
        
        Task AddCarToAgencyAsync(long carId, long rentACarId);
    }
}
