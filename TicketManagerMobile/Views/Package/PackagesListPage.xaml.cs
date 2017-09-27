using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using TicketManagerMobile.ViewModels;
using TicketManagerMobile.Util;
using TicketApi.Interfaces;

namespace TicketManagerMobile.Views.Package
{
    public sealed partial class PackagesListPage : Page
    {
        public PackagesListModel ViewModel { get; set; }

        public PackagesListPage()
        {
            InitializeComponent();
            ViewModel = new PackagesListModel(AutofacConfig.Resolve<INavigationService>());
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is List<TicketApi.Models.Package> packages)
            {
                ViewModel.Packages.AddRange(packages);
            }
        }
    }
}
