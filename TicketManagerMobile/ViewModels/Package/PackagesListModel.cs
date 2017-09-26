using System.Collections.Generic;
using TicketApi.Models;

namespace TicketManagerMobile.ViewModels
{
    public class PackagesListModel : BaseViewModel
    {
        private List<Package> _packages;
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
                // TODO: Open package's details.
            }
        }
    }
}
