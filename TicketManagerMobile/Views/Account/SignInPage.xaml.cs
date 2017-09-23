using Windows.UI.Xaml.Controls;
using TicketApi.Interfaces;
using TicketManagerMobile.ViewModels.Account;
using static TicketManagerMobile.Util.AutofacConfig;

namespace TicketManagerMobile.Views.Account
{
    public sealed partial class SignInPage : Page
    {
        public SignInViewModel ViewModel { get; set; }

        public SignInPage()
        {
            InitializeComponent();
            ViewModel = new SignInViewModel(Resolve<IAuthenticationService>(),
                                            Resolve<INavigationService>());
        }
    }
}
