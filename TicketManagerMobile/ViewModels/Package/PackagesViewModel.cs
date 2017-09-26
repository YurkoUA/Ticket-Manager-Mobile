using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketApi.Enums;
using TicketApi.Interfaces;
using TicketManagerMobile.Util;

namespace TicketManagerMobile.ViewModels
{
    public class PackagesViewModel : AuthorizedViewModel
    {
        private INavigationService _navigaionService;
        private IPackageService _packageService;

        private int _selectedPivotIndex = 0;

        public PackagesViewModel(IAuthenticationService authenticationService, INavigationService navigationService, IPackageService packageService) : base(authenticationService)
        {
            _navigaionService = navigationService;
            _packageService = packageService;

            AllPackages = new PackagesCategoryViewModel(_packageService, PackagesFilter.All);
            OpenedPackages = new PackagesCategoryViewModel(_packageService, PackagesFilter.Opened);
            SpecialPackages = new PackagesCategoryViewModel(_packageService, PackagesFilter.Special);

            SetTotalCountAsync();
        }

        public PackagesCategoryViewModel AllPackages { get; set; }
        public PackagesCategoryViewModel OpenedPackages { get; set; }
        public PackagesCategoryViewModel SpecialPackages { get; set; }

        public int SelectedPivotIndex
        {
            get => _selectedPivotIndex;
            set
            {
                if (_selectedPivotIndex != value)
                {
                    _selectedPivotIndex = value;
                    OnPropertyChanged(nameof(SelectedPivotIndex));
                }
            }
        }

        public void Refresh()
        {
            SetTotalCountAsync();

            AllPackages.Refresh();
            OpenedPackages.Refresh();
            SpecialPackages.Refresh();
        }

        private async void SetTotalCountAsync()
        {
            var count = await _packageService.GetCount();

            AllPackages.TotalCount = count.Total;
            OpenedPackages.TotalCount = count.Opened;
            SpecialPackages.TotalCount = count.Special;
        }
    }
}
