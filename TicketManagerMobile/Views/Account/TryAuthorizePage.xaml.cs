using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using TicketApi.Interfaces;
using TicketManagerMobile.ViewModels.Account;
using static TicketManagerMobile.Util.AutofacConfig;

namespace TicketManagerMobile.Views.Account
{
    public sealed partial class TryAuthorizePage : Page
    {
        public TryAuthorizeViewModel ViewModel { get; set; }

        public TryAuthorizePage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ViewModel = new TryAuthorizeViewModel(Resolve<IAuthenticationService>(), Resolve<INavigationService>(), Resolve<ICredentialService>());
            ViewModel.TryAuthorizeAsync(ViewModel.GetCredential());
        }
    }
}
