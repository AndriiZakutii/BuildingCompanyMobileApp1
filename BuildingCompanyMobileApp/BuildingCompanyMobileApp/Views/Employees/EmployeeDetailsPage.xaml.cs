using BuildingCompanyMobileApp.ViewModels.Employees;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BuildingCompanyMobileApp.Views.Employees
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmployeeDetailsPage : ContentPage
    {
        public EmployeeDetailsPage()
        {
            InitializeComponent();
            BindingContext = new EmployeeDetailsViewModel();
        }
    }
}