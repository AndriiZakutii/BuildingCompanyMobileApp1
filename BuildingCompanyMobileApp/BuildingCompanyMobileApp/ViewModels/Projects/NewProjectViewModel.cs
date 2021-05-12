using BuildingCompanyMobileApp.Services.APIRepositories;
using BuildingCompanyModel;
using Refit;
using System;
using Xamarin.Forms;

namespace BuildingCompanyMobileApp.ViewModels.Projects
{
    class NewProjectViewModel : BaseViewModel
    {
        private string name;
        private decimal cost;
        private DateTime start;

        public NewProjectViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !string.IsNullOrWhiteSpace(name)
                && !(cost <= 0);
        }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public DateTime Start
        {
            get => start;
            set => SetProperty(ref start, value);
        }

        public decimal Cost
        {
            get => cost;
            set => SetProperty(ref cost, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Project newProject = new Project()
            {
                Name = Name,
                Cost = Cost,
                Start = Start,
            };

            var client = RestService.For<IBuildingCompanyRepository>("http://10.0.2.2:5000");
            await client.AddProject(newProject);

            await Shell.Current.GoToAsync("..");
        }
    }
}
