using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using TicketApi.Interfaces;
using TicketManagerMobile.ViewModels;
using static TicketManagerMobile.Util.AutofacConfig;

namespace TicketManagerMobile.Views.Package
{
    public sealed partial class PackageDetailsPage : Page
    {
        public PackageDetailsViewModel ViewModel { get; set; }

        public PackageDetailsPage()
        {
            InitializeComponent();
            ViewModel = new PackageDetailsViewModel(Resolve<IAuthenticationService>(),
                                                    Resolve<INavigationService>(),
                                                    Resolve<IPackageService>());
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is int packageId)
            {
                ViewModel.LoadPackageAsync(packageId);
            }
        }
    }
}
