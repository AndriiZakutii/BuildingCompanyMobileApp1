using BuildingCompanyMobileApp.Services.APIRepositories;
using BuildingCompanyModel;
using Refit;
using Xamarin.Forms;

namespace BuildingCompanyMobileApp.ViewModels.Employees
{
    class NewEmployeeViewModel : BaseViewModel
    {
        private string name;
        private string surname;
        private decimal salary;

        public NewEmployeeViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !string.IsNullOrWhiteSpace(name)
                && !string.IsNullOrWhiteSpace(surname)
                && !(salary < 0);
        }

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

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Employee newEmployee = new Employee()
            {
                Name = Name,
                Surname = Surname,
                Salary = Salary,
            };

            var client = RestService.For<IBuildingCompanyRepository>("http://10.0.2.2:5000");
            await client.AddEmployee(newEmployee);

            await Shell.Current.GoToAsync("..");
        }
    }
}
