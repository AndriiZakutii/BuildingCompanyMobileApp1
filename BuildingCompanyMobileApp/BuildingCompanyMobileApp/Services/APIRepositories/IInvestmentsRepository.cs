using BuildingCompanyModel;
using Refit;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BuildingCompanyMobileApp.Services.APIRepositories
{
    interface IInvestmentsRepository
    {
        [Get("/api/investments")]
        Task<IEnumerable<Investment>> GetInvestments();
    }
}
