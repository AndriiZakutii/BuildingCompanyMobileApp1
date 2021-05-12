using BuildingCompanyModel;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuildingCompanyMobileApp.Services.APIRepositories
{
    interface IInvestorsRepository
    {
        [Get("/api/investors")]
        Task<IEnumerable<Investor>> GetInvestors();

        [Get("/api/investors/{id}")]
        Task<Investor> GetInvestor(int id);

        [Post("/api/investors")]
        Task AddInvestor([Body] Investor investor);
    }
}
