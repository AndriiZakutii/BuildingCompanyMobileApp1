using BuildingCompanyMobileApp.ViewModels.Investors;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BuildingCompanyMobileApp.Views.Investors
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InvestorsPage : ContentPage
    {
        InvestorsViewModel _viewModel;

        public InvestorsPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new InvestorsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}