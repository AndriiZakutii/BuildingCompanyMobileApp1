using BuildingCompanyMobileApp.Services.APIRepositories;
using BuildingCompanyMobileApp.Views.Investors;
using BuildingCompanyModel;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Refit;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BuildingCompanyMobileApp.ViewModels.Investors
{
    class InvestorsViewModel : BaseViewModel
    {
        private Investor _selectedInvestor;

        public ObservableCollection<Investor> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<Investor> ItemTapped { get; }
        public Command SaveFileCommand { get; }

        public InvestorsViewModel()
        {
            Title = "Investors";
            Items = new ObservableCollection<Investor>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            ItemTapped = new Command<Investor>(OnItemSelected);
            AddItemCommand = new Command(OnAddItem);

            SaveFileCommand = new Command(() =>
            {
                try
                {
                    string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    string fileName = "investors.txt";

                    StringBuilder dataBuilder = new StringBuilder();

                    foreach (var item in Items)
                        dataBuilder.Append($"{item}\n");

                    File.WriteAllText(Path.Combine(folderPath, fileName), dataBuilder.ToString());
                }
                catch (Exception ex)
                {
                    Crashes.TrackError(ex);
                }
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var client = RestService.For<IInvestorsRepository>("http://10.0.2.2:5000");
                var items = await client.GetInvestors();

                foreach (var item in items)
                {
                    Items.Add(item);
                }

                OnPropertyChanged(nameof(Items));
                Analytics.TrackEvent("Investors loaded");
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

        public Investor SelectedItem
        {
            get => _selectedInvestor;
            set
            {
                SetProperty(ref _selectedInvestor, value);
                OnItemSelected(value);
            }
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewInvestorPage));
        }

        private async void OnItemSelected(Investor investor)
        {
            if (investor == null)
                return;

            await Shell.Current.GoToAsync($"{nameof(InvestorDetailsPage)}?{nameof(InvestorDetailsViewModel.InvestorId)}={investor.Id}");
        }
    }
}
