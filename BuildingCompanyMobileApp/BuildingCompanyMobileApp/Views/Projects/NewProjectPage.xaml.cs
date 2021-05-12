using BuildingCompanyMobileApp.ViewModels.Projects;
using BuildingCompanyModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BuildingCompanyMobileApp.Views.Projects
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewProjectPage : ContentPage
    {
        public Project Project { get; set; }

        public NewProjectPage()
        {
            InitializeComponent();
            BindingContext = new NewProjectViewModel();
        }
    }
}