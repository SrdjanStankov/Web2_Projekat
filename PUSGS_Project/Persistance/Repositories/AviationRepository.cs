using Core.Entities;
using Core.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class AviationRepository : IAviationRepository
    {
        public Task<long> AddAsync(AviationCompany company)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<AviationCompany>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<AviationCompany> GetByIdAsync(long id)
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveAsync(long id)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(AviationCompany company)
        {
            throw new System.NotImplementedException();
        }
    }
}