using TicketApi.Enums;
using TicketApi.Interfaces;
using TicketManagerMobile.Views.Package;

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

            AllPackages = new PackagesCategoryViewModel(_packageService, _navigaionService, PackagesFilter.All);
            OpenedPackages = new PackagesCategoryViewModel(_packageService, _navigaionService, PackagesFilter.Opened);
            SpecialPackages = new PackagesCategoryViewModel(_packageService, _navigaionService, PackagesFilter.Special);

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

        public void OpenSearchPage()
        {
            _navigaionService.NavigateTo(typeof(PackagesSearchPage));
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
