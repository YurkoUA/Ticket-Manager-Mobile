using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManagerMobile.ViewModels.Home
{
    public class HomeViewModel : BaseViewModel
    {
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
    }
}
