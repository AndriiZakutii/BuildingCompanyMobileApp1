using BuildingCompanyMobileApp.Views.Employees;
using BuildingCompanyMobileApp.Views.Investors;
using BuildingCompanyMobileApp.Views.Projects;
using System;
using Xamarin.Forms;

namespace BuildingCompanyMobileApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ProjectDetailsPage), typeof(ProjectDetailsPage));
            Routing.RegisterRoute(nameof(NewProjectPage), typeof(NewProjectPage));

            Routing.RegisterRoute(nameof(EmployeeDetailsPage), typeof(EmployeeDetailsPage));
            Routing.RegisterRoute(nameof(NewEmployeePage), typeof(NewEmployeePage));

            Routing.RegisterRoute(nameof(InvestorDetailsPage), typeof(InvestorDetailsPage));
            Routing.RegisterRoute(nameof(NewInvestorPage), typeof(NewInvestorPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Current.GoToAsync("//LoginPage");
        }
    }
}
