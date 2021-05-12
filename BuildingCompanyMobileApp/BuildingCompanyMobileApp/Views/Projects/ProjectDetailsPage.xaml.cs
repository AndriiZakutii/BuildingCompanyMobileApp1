using BuildingCompanyMobileApp.ViewModels.Projects;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BuildingCompanyMobileApp.Views.Projects
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProjectDetailsPage : ContentPage
    {
        public ProjectDetailsPage()
        {
            InitializeComponent();
            BindingContext = new ProjectDetailsViewModel();
        }
    }
}