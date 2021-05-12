using BuildingCompanyMobileApp.Services.APIRepositories;
using BuildingCompanyModel;
using Refit;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using Xamarin.Forms;

namespace BuildingCompanyMobileApp.ViewModels.Employees
{
    [QueryProperty(nameof(EmployeeId), nameof(EmployeeId))]
    class EmployeeDetailsViewModel : BaseViewModel
    {
        private int employeeId;
        private string name;
        private string surname;
        private decimal salary;
        private Position position;

        public ObservableCollection<Project> Projects { get; private set; }

        public int Id { get; set; }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public string Surname
        {
            get => surname;
            set => SetProperty(ref surname, value);
        }

        public decimal Salary
        {
            get => salary;
            set => SetProperty(ref salary, value);
        }

        public Position Position
        {
            get => position;
            set => SetProperty(ref position, value);
        }

        public int EmployeeId
        {
            get => employeeId;

            set
            {
                employeeId = value;
                LoadEmployeeId(value);
            }
        }

        public async void LoadEmployeeId(int employeeId)
        {
            try
            {
                var client = RestService.For<IBuildingCompanyRepository>("http://10.0.2.2:5000");
                var employee = await client.GetEmployee(employeeId);
                Id = employee.Id;
                Name = employee.Name;
                Surname = employee.Surname;
                Salary = employee.Salary;
                Position = employee.Position;

                var projects = await client.GetProjects();
                var employeeProjects = projects.Where(project => project.Employees.Where(e => e.Id == employee.Id).Count() > 0);
                Projects = new ObservableCollection<Project>(employeeProjects);
                OnPropertyChanged(nameof(Projects));
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
