using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface IBranchRepository
    {
        Task<Branch> GetAsync(long id);

        Task<bool> AddAsync(Branch branch);

        Task DeleteAsync(long id);

        Task UpdateAsync(Branch branch);
    }
}
