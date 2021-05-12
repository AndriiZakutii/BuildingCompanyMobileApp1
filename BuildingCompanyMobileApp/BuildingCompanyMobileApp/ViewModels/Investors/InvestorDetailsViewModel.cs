using BuildingCompanyMobileApp.Services.APIRepositories;
using BuildingCompanyModel;
using Refit;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Xamarin.Forms;
using System.Linq;

namespace BuildingCompanyMobileApp.ViewModels.Investors
{
    [QueryProperty(nameof(InvestorId), nameof(InvestorId))]
    class InvestorDetailsViewModel : BaseViewModel
    {
        private int investorId;
        private string name;
        private string surname;
        private string passportNo;

        public ObservableCollection<Project> Projects { get; private set; }

        public int Id { get; set; }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public string Surname
        {
            get => surname;
            set => SetProperty(ref surname, value);
        }

        public string PassportNo
        {
            get => passportNo;
            set => SetProperty(ref passportNo, value);
        }

        public int InvestorId
        {
            get => investorId;

            set
            {
                investorId = value;
                LoadInvestorId(value);
            }
        }

        public async void LoadInvestorId(int investorId)
        {
            try
            {
                var client = RestService.For<IBuildingCompanyRepository>("http://10.0.2.2:5000");
                var investor = await client.GetInvestor(investorId);
                Id = investor.Id;
                Name = investor.Name;
                Surname = investor.Surname;
                PassportNo = investor.PassportNo;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
