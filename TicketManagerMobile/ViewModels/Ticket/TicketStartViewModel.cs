using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketApi.Interfaces;

namespace TicketManagerMobile.ViewModels
{
    public class TicketStartViewModel : AuthorizedViewModel
    {
        private INavigationService _navigationService;

        public TicketStartViewModel(IAuthenticationService authenticationService, INavigationService navigationService) : base(authenticationService)
        {
            _navigationService = navigationService;
        }
    }
}
