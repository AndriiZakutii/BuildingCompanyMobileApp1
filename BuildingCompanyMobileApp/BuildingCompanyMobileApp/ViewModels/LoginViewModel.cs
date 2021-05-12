using BuildingCompanyMobileApp.Views;
using Xamarin.Forms;

namespace BuildingCompanyMobileApp.ViewModels.Projects
{
    class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }

        private async void OnLoginClicked(object obj)
        {
            await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }
    }
}
