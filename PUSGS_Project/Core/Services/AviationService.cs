using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.ViewModels.Aviation;
using Core.ViewModels.Aviation.Requests;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Services
{
    public class AviationService : IAviationService
    {
        private readonly IAviationRepository _aviationRepo;

        public AviationService(IAviationRepository aviationRepository)
        {
            _aviationRepo = aviationRepository;
        }

        public Task<long> AddAviationCompanyAsync(AddOrUpdateAviationCompanyRequestModel model)
        {
            var company = MapToCompany(model);

            return _aviationRepo.AddAsync(company);
        }

        private static AviationCompany MapToCompany(AddOrUpdateAviationCompanyRequestModel model)
        {
            var address = new Location(model.Address?.CityName, model.Address?.X, model.Address?.Y);
            return new AviationCompany
            {
                Address = address,
                Description = model.Description,
                Name = model.Name
            };
        }

        public Task DeleteAviationCompanyAsync(long id)
        {
            return _aviationRepo.RemoveAsync(id);
        }

        public async Task<List<AviationCompanyModel>> GetAllCompaniesAsync()
        {
            var companies = await _aviationRepo.GetAllAsync();
            return companies.Select(c => new AviationCompanyModel(c)).ToList();
        }

        public async Task<AviationCompanyModel> GetCompanyByIdAsync(long id)
        {
            var company = await _aviationRepo.GetByIdAsync(id);
            return new AviationCompanyModel(company);
        }

        public Task UpdateAviationCompanyAsync(AddOrUpdateAviationCompanyRequestModel model)
        {
            var company = MapToCompany(model);
            return _aviationRepo.UpdateAsync(company);
        }
    }
}