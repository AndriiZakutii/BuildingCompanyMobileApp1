using BuildingCompanyMobileApp.ViewModels.Employees;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BuildingCompanyMobileApp.Views.Employees
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmployeesPage : ContentPage
    {
        EmployeesViewModel _viewModel;

        public EmployeesPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new EmployeesViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}