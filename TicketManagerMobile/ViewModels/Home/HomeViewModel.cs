using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketApi.Interfaces;
using TicketManagerMobile.Views.Color;
using TicketManagerMobile.Views.Home;
using TicketManagerMobile.Views.Package;
using TicketManagerMobile.Views.Serial;

namespace TicketManagerMobile.ViewModels.Home
{
    public class HomeViewModel : BaseViewModel
    {
        public HomeViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        private INavigationService _navigationService;
        private bool _isMenuOpened;

        public bool IsMenuOpened
        {
            get => _isMenuOpened;
            set
            {
                _isMenuOpened = value;
                OnPropertyChanged(nameof(IsMenuOpened));
            }
        }

        public void MenuOpenedChanged()
        {
            IsMenuOpened = !IsMenuOpened;
        }

        public void CloseMenu()
        {
            IsMenuOpened = false;
        }

        public void OpenColorsPage()
        {
            _navigationService.NavigateTo(typeof(ColorsPage));
            CloseMenu();
            ClearHistory();
        }

        public void OpenSeriesPage()
        {
            _navigationService.NavigateTo(typeof(SeriesPage));
            CloseMenu();
            ClearHistory();
        }

        public void OpenPackagesPage()
        {
            _navigationService.NavigateTo(typeof(PackagesPage));
            CloseMenu();
            ClearHistory();
        }

        private void ClearHistory()
        {
            _navigationService.ClearHistory();
        }
    }
}
