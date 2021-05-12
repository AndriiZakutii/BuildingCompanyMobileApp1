using BuildingCompanyModel;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuildingCompanyMobileApp.Services.APIRepositories
{
    interface IProjectsRepository
    {
        [Get("/api/projects")]
        Task<IEnumerable<Project>> GetProjects();

        [Get("/api/projects/{id}")]
        Task<Project> GetProject(int id);

        [Post("/api/projects")]
        Task AddProject([Body] Project project);
    }
}
