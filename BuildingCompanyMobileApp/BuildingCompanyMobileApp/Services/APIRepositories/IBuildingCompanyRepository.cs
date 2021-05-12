namespace BuildingCompanyMobileApp.Services.APIRepositories
{
    interface IBuildingCompanyRepository :
        IProjectsRepository,
        IInvestorsRepository,
        IEmployeesRepository,
        IInvestmentsRepository
    {
    }
}
