using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.ViewModels.Aviation;
using Core.ViewModels.Aviation.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Services
{
    public class AviationService : IAviationService
    {
        private IAviationRepository _repo;

        public AviationService(IAviationRepository aviationRepository)
        {
            this._repo = aviationRepository;
        }

        public Task<long> AddAviationCompanyAsync(AddOrUpdateAviationCompanyRequestModel model)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAviationCompanyAsync(long id)
        {
            return Task.CompletedTask;
        }

        public Task<List<AviationCompanyModel>> GetAllCompaniesAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<AviationCompanyModel> GetCompanyByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAviationCompanyAsync(AddOrUpdateAviationCompanyRequestModel model)
        {
            return Task.CompletedTask;
        }
    }
}