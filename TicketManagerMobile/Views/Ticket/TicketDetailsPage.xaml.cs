using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using TicketApi.Interfaces;
using TicketManagerMobile.ViewModels;
using static TicketManagerMobile.Util.AutofacConfig;

namespace TicketManagerMobile.Views.Ticket
{
    public sealed partial class TicketDetailsPage : Page
    {
        public TicketDetailsViewModel ViewModel { get; set; }

        public TicketDetailsPage()
        {
            InitializeComponent();
            ViewModel = new TicketDetailsViewModel(Resolve<IAuthenticationService>(), Resolve<ITicketService>(), Resolve<INavigationService>());
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is int ticketId)
            {
                ViewModel.LoadTicketAsync(ticketId);
            }
        }
    }
}
