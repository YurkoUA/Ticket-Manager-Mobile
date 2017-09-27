using System.Collections.Generic;
using TicketApi.Interfaces;
using TicketApi.Models;
using TicketManagerMobile.Views.Package;

namespace TicketManagerMobile.ViewModels
{
    public class PackagesListModel : BaseViewModel
    {
        public PackagesListModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        private INavigationService _navigationService;

        private List<Package> _packages = new List<Package>();
        private Package _selectedPackage;

        public List<Package> Packages
        {
            get => _packages;
            set
            {
                if (_packages != value)
                {
                    _packages = value;
                    OnPropertyChanged(nameof(Packages));
                }
            }
        }

        public Package SelectedPackage
        {
            get => _selectedPackage;
            set
            {
                if (_selectedPackage != value)
                {
                    _selectedPackage = value;
                    OnPropertyChanged(nameof(SelectedPackage));
                }
            }
        }

        public void OpenPackageDetails()
        {
            if (SelectedPackage != null)
            {
                _navigationService.NavigateTo(typeof(PackageDetailsPage), SelectedPackage.Id);
            }
        }
    }
}
