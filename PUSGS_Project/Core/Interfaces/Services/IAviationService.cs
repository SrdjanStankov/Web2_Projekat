using Core.ViewModels.Aviation;
using Core.ViewModels.Aviation.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface IAviationService
    {
        Task<List<AviationCompanyModel>> GetAllCompaniesAsync();

        Task<AviationCompanyModel> GetCompanyByIdAsync(int id);

        Task<long> AddAviationCompanyAsync(AddOrUpdateAviationCompanyRequestModel model);

        Task UpdateAviationCompanyAsync(AddOrUpdateAviationCompanyRequestModel model);

        Task DeleteAviationCompanyAsync(long id);
    }
}