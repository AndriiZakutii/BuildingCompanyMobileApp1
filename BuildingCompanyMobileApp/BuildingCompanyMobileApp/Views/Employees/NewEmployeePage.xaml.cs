using BuildingCompanyMobileApp.ViewModels.Employees;
using BuildingCompanyModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BuildingCompanyMobileApp.Views.Employees
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewEmployeePage : ContentPage
    {
        public Employee Employee { get; set; }

        public NewEmployeePage()
        {
            InitializeComponent();
            BindingContext = new NewEmployeeViewModel();
        }
    }
}