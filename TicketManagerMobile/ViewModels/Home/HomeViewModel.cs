using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketApi.Interfaces;
using TicketManagerMobile.Views.Color;
using TicketManagerMobile.Views.Home;
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
                OnPropertyChanged("IsMenuOpened");
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
        }

        public void OpenSeriesPage()
        {
            _navigationService.NavigateTo(typeof(SeriesPage));
            CloseMenu();
        }
    }
}
