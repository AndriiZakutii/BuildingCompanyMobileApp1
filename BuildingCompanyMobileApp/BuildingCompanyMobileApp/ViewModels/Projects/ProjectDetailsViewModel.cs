using BuildingCompanyMobileApp.Services.APIRepositories;
using BuildingCompanyModel;
using Microsoft.AppCenter.Crashes;
using Refit;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Xamarin.Forms;

namespace BuildingCompanyMobileApp.ViewModels.Projects
{
    [QueryProperty(nameof(ProjectId), nameof(ProjectId))]
    class ProjectDetailsViewModel : BaseViewModel
    {
        private int projectId;
        private string name;
        private decimal cost;
        private DateTime start;
        private ProjectType type;
        private ProjectStage stage;

        public ObservableCollection<Employee> Employees { get; private set; }

        public int Id { get; set; }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public decimal Cost
        {
            get => cost;
            set => SetProperty(ref cost, value);
        }

        public DateTime Start
        {
            get => start;
            set => SetProperty(ref start, value);
        }

        public ProjectType Type
        {
            get => type;
            set => SetProperty(ref type, value);
        }

        public ProjectStage Stage
        {
            get => stage;
            set => SetProperty(ref stage, value);
        }

        public int ProjectId
        {
            get => projectId;

            set
            {
                projectId = value;
                LoadProjectId(value);
            }
        }

        public async void LoadProjectId(int projectId)
        {
            try
            {
                var client = RestService.For<IBuildingCompanyRepository>("http://10.0.2.2:5000");
                var project = await client.GetProject(projectId);
                Id = project.Id;
                Name = project.Name;
                Cost = project.Cost;
                Start = project.Start;
                Type = project.Type;
                Stage = project.Stage;

                Employees = new ObservableCollection<Employee>(project.Employees);
                var count = Employees.Count;
                OnPropertyChanged(nameof(Employees));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Crashes.TrackError(ex);
            }
        }
    }
}
