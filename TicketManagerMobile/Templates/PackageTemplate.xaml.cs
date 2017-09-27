using Windows.UI.Xaml.Controls;
using TicketApi.Models;

namespace TicketManagerMobile.Templates
{
    public sealed partial class PackageTemplate : UserControl
    {
        public Package Package => DataContext as Package;

        public PackageTemplate()
        {
            InitializeComponent();
        }
    }
}
