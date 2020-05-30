using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface IFlightRepository
    {
        Task<long> AddAsync(Flight company);

        Task<List<Flight>> GetAllAsync();

        Task<Flight> GetByIdAsync(long id);

        Task RemoveAsync(long id);

        Task UpdateAsync(Flight company);
    }
}