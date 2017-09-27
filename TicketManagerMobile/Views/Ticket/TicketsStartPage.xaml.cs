using Windows.UI.Xaml.Controls;
using TicketApi.Interfaces;
using TicketManagerMobile.ViewModels;
using static TicketManagerMobile.Util.AutofacConfig;

namespace TicketManagerMobile.Views.Ticket
{
    public sealed partial class TicketsStartPage : Page
    {
        public TicketStartViewModel ViewModel { get; set; }

        public TicketsStartPage()
        {
            InitializeComponent();
            ViewModel = new TicketStartViewModel(Resolve<IAuthenticationService>(), Resolve<INavigationService>());
        }
    }
}
