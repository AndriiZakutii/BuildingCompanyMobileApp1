using BuildingCompanyMobileApp.Services.APIRepositories;
using BuildingCompanyMobileApp.Views.Projects;
using BuildingCompanyModel;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Refit;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BuildingCompanyMobileApp.ViewModels.Projects
{
    class ProjectsViewModel : BaseViewModel
    {
        private Project _selectedProject;

        public ObservableCollection<Project> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<Project> ItemTapped { get; }

        public ProjectsViewModel()
        {
            Title = "Projects";
            Items = new ObservableCollection<Project>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            ItemTapped = new Command<Project>(OnItemSelected);
            AddItemCommand = new Command(OnAddItem);
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var client = RestService.For<IBuildingCompanyRepository>("http://10.0.2.2:5000");
                var items = await client.GetProjects();

                foreach (var item in items)
                {
                    Items.Add(item);
                }

                OnPropertyChanged(nameof(Items));
                Analytics.TrackEvent("Projects loaded");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                Crashes.TrackError(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public Project SelectedItem
        {
            get => _selectedProject;
            set
            {
                SetProperty(ref _selectedProject, value);
                OnItemSelected(value);
            }
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewProjectPage));
        }

        private async void OnItemSelected(Project project)
        {
            if (project == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ProjectDetailsPage)}?{nameof(ProjectDetailsViewModel.ProjectId)}={project.Id}");
        }
    }
}
