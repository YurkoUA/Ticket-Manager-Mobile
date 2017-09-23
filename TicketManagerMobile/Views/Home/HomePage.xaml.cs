using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using TicketApi.Interfaces;
using TicketManagerMobile.Util;
using TicketManagerMobile.ViewModels.Home;

namespace TicketManagerMobile.Views.Home
{
    public sealed partial class HomePage : Page
    {
        public HomeViewModel ViewModel { get; set; }

        public HomePage()
        {
            InitializeComponent();
            ViewModel = new HomeViewModel();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var navigationService = AutofacConfig.Resolve<INavigationService>();

            navigationService.ClearHistory();
            navigationService.ConfigureFrame(myFrame);
        }
    }
}
