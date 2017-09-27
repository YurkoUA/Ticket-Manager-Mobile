using Windows.UI.Xaml.Controls;
using TicketApi.Interfaces;
using TicketManagerMobile.ViewModels;
using static TicketManagerMobile.Util.AutofacConfig;

namespace TicketManagerMobile.Views.Package
{
    public sealed partial class PackagesSearchPage : Page
    {
        public PackageSearchViewModel ViewModel { get; set; }

        public PackagesSearchPage()
        {
            InitializeComponent();
            ViewModel = new PackageSearchViewModel(Resolve<IPackageService>(), Resolve<INavigationService>());
        }
    }
}
