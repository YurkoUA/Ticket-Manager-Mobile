using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketApi.Interfaces;
using TicketManagerMobile.Views.Ticket;

namespace TicketManagerMobile.ViewModels
{
    public class TicketStartViewModel : AuthorizedViewModel
    {
        private INavigationService _navigationService;

        public TicketStartViewModel(IAuthenticationService authenticationService, INavigationService navigationService) : base(authenticationService)
        {
            _navigationService = navigationService;
        }

        public void OpenSearchPage()
        {
            _navigationService.NavigateTo(typeof(TicketSearchPage));
        }
    }
}
