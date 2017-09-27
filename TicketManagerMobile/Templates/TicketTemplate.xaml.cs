using Windows.UI.Xaml.Controls;
using TicketApi.Models;

namespace TicketManagerMobile.Templates
{
    public sealed partial class TicketTemplate : UserControl
    {
        public Ticket Ticket => DataContext as Ticket;

        public TicketTemplate()
        {
            InitializeComponent();
        }
    }
}
