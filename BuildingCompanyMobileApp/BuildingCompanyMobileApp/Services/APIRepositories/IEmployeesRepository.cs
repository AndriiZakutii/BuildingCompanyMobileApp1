using BuildingCompanyModel;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuildingCompanyMobileApp.Services.APIRepositories
{
    interface IEmployeesRepository
    {
        [Get("/api/employees")]
        Task<IEnumerable<Employee>> GetEmployees();

        [Get("/api/employees/{id}")]
        Task<Employee> GetEmployee(int id);

        [Post("/api/employees")]
        Task AddEmployee([Body] Employee employee);
    }
}
