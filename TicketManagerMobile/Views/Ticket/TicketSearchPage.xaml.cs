using Windows.UI.Xaml.Controls;
using TicketApi.Interfaces;
using TicketManagerMobile.ViewModels;
using static TicketManagerMobile.Util.AutofacConfig;

namespace TicketManagerMobile.Views.Ticket
{
    public sealed partial class TicketSearchPage : Page
    {
        public TicketSearchViewModel ViewModel { get; set; }

        public TicketSearchPage()
        {
            InitializeComponent();
            ViewModel = new TicketSearchViewModel(Resolve<ITicketService>(), Resolve<INavigationService>());
        }
    }
}
