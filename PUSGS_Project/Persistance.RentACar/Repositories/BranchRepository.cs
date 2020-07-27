using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.Repositories;

namespace Persistance.RentACar.Repositories
{
    public class BranchRepository : IBranchRepository
    {
        private readonly RentACarDbContext context;

        public BranchRepository(RentACarDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> AddAsync(Branch branch)
        {
            var b = await context.FindAsync<Branch>(branch.Id);
            if (b is object)
            {
                return false;
            }
            await context.AddAsync(branch);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task DeleteAsync(long id)
        {
            var branch = await context.Branches.FindAsync(id);
            context.Branches.Remove(branch);
            await context.SaveChangesAsync();
        }

        public async Task<Branch> GetAsync(long id) => await context.FindAsync<Branch>(id);

        public async Task UpdateAsync(Branch branch)
        {
            context.Update(branch);
            await context.SaveChangesAsync();
        }
    }
}
