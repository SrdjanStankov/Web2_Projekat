using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface IAviationRepository
    {
        Task<long> AddAsync(AviationCompany company);

        Task RemoveAsync(long id);

        Task<List<AviationCompany>> GetAllAsync();

        Task<AviationCompany> GetByIdAsync(long id);

        Task UpdateAsync(AviationCompany company);
    }
}