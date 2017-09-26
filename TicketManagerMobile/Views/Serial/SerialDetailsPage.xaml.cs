using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using TicketApi.Interfaces;
using TicketManagerMobile.Util;
using TicketManagerMobile.ViewModels;

namespace TicketManagerMobile.Views.Serial
{
    public sealed partial class SerialDetailsPage : Page
    {
        public SerialDetailsViewModel ViewModel { get; set; }

        public SerialDetailsPage()
        {
            InitializeComponent();
            ViewModel = new SerialDetailsViewModel(AutofacConfig.Resolve<ISerialService>(),
                                                   AutofacConfig.Resolve<INavigationService>());
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is int serialId)
            {
                ViewModel.LoadSerialAsync(serialId);
            }
        }
    }
}
