using BuildingCompanyMobileApp.Services.APIRepositories;
using BuildingCompanyMobileApp.Views.Employees;
using BuildingCompanyModel;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Refit;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BuildingCompanyMobileApp.ViewModels.Employees
{
    class EmployeesViewModel : BaseViewModel
    {
        private Employee _selectedEmployee;

        public ObservableCollection<Employee> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<Employee> ItemTapped { get; }

        public EmployeesViewModel()
        {
            Title = "Employees";
            Items = new ObservableCollection<Employee>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            ItemTapped = new Command<Employee>(OnItemSelected);
            AddItemCommand = new Command(OnAddItem);
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();

                var client = RestService.For<IBuildingCompanyRepository>("http://10.0.2.2:5000");
                var items = await client.GetEmployees();

                foreach (var item in items)
                {
                    Items.Add(item);
                }

                OnPropertyChanged(nameof(Items));
                Analytics.TrackEvent("Employees loaded");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                Crashes.TrackError(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public Employee SelectedItem
        {
            get => _selectedEmployee;
            set
            {
                SetProperty(ref _selectedEmployee, value);
                OnItemSelected(value);
            }
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewEmployeePage));
        }

        private async void OnItemSelected(Employee employee)
        {
            if (employee == null)
                return;

            await Shell.Current.GoToAsync($"{nameof(EmployeeDetailsPage)}?{nameof(EmployeeDetailsViewModel.EmployeeId)}={employee.Id}");
        }
    }
}
