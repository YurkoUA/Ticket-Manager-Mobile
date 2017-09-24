using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using TicketApi.Interfaces;
using TicketManagerMobile.Util;
using TicketManagerMobile.ViewModels;

namespace TicketManagerMobile.Views.Serial
{
    public sealed partial class SeriesPage : Page
    {
        public SeriesViewModel ViewModel { get; set; }

        public SeriesPage()
        {
            InitializeComponent();
            ViewModel = new SeriesViewModel(AutofacConfig.Resolve<ISerialService>(),
                                            AutofacConfig.Resolve<INavigationService>());
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ViewModel.LoadSeriesAsync();
        }
    }
}
