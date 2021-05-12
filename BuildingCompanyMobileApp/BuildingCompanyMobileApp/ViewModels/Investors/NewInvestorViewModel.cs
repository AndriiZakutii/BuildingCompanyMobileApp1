using BuildingCompanyMobileApp.Services.APIRepositories;
using BuildingCompanyModel;
using Refit;
using Xamarin.Forms;

namespace BuildingCompanyMobileApp.ViewModels.Investors
{
    class NewInvestorViewModel : BaseViewModel
    {
        private string name;
        private string surname;
        private string passportNo;

        public NewInvestorViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            PropertyChanged += (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !string.IsNullOrWhiteSpace(name)
                && !string.IsNullOrWhiteSpace(surname)
                && !string.IsNullOrWhiteSpace(passportNo);
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

        public string PassportNo
        {
            get => passportNo;
            set => SetProperty(ref passportNo, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Investor newInvestor = new Investor()
            {
                Name = Name,
                Surname = Surname,
                PassportNo = PassportNo,
            };

            var client = RestService.For<IBuildingCompanyRepository>("http://10.0.2.2:5000");
            await client.AddInvestor(newInvestor);

            await Shell.Current.GoToAsync("..");
        }
    }
}
