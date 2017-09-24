using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using TicketManagerMobile.Util;
using TicketManagerMobile.ViewModels;
using TicketApi.Interfaces;

namespace TicketManagerMobile.Views.Color
{
    public sealed partial class ColorsPage : Page
    {
        public ColorsViewModel ViewModel { get; set; }

        public ColorsPage()
        {
            InitializeComponent();
            ViewModel = new ColorsViewModel(AutofacConfig.Resolve<IColorService>(), AutofacConfig.Resolve<INavigationService>());
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ViewModel.LoadColorsAsync();
        }
    }
}
