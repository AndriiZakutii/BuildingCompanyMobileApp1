using BuildingCompanyMobileApp.ViewModels.Investors;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BuildingCompanyMobileApp.Views.Investors
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InvestorDetailsPage : ContentPage
    {
        public InvestorDetailsPage()
        {
            InitializeComponent();
            BindingContext = new InvestorDetailsViewModel();
        }
    }
}