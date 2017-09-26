using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TicketApi.Interfaces;
using TicketManagerMobile.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using static TicketManagerMobile.Util.AutofacConfig;

namespace TicketManagerMobile.Views.Package
{
    public sealed partial class PackagesPage : Page
    {
        public PackagesViewModel ViewModel { get; set; }

        public PackagesPage()
        {
            InitializeComponent();
            ViewModel = new PackagesViewModel(Resolve<IAuthenticationService>(), Resolve<INavigationService>(), Resolve<IPackageService>());
        }
    }
}
