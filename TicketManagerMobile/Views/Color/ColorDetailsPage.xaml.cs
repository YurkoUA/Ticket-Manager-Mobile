using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using TicketApi.Interfaces;
using TicketManagerMobile.Util;
using TicketManagerMobile.ViewModels;

namespace TicketManagerMobile.Views.Color
{
    public sealed partial class ColorDetailsPage : Page
    {
        public ColorDetailsViewModel ViewModel { get; set; }

        public ColorDetailsPage()
        {
            InitializeComponent();
            ViewModel = new ColorDetailsViewModel(AutofacConfig.Resolve<IColorService>(),
                                                  AutofacConfig.Resolve<INavigationService>());
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is int colorId)
            {
                ViewModel.LoadColorAsync(colorId);
            }
        }
    }
}
