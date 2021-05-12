using BuildingCompanyMobileApp.ViewModels.Investors;
using BuildingCompanyModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BuildingCompanyMobileApp.Views.Investors
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewInvestorPage : ContentPage
    {
        public Investor Investor { get; set; }

        public NewInvestorPage()
        {
            InitializeComponent();
            BindingContext = new NewInvestorViewModel();
        }
    }
}