using BuildingCompanyMobileApp.ViewModels.Projects;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BuildingCompanyMobileApp.Views.Projects
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProjectsPage : ContentPage
    {
        ProjectsViewModel _viewModel;

        public ProjectsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ProjectsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}