using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketApi.Interfaces;
using TicketManagerMobile.Views.Color;
using TicketManagerMobile.Views.Home;

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

        public void OpenColorsPage()
        {
            _navigationService.NavigateTo(typeof(ColorsPage));
        }
    }
}
