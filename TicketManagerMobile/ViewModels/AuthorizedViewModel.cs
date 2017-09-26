using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketApi.Interfaces;

namespace TicketManagerMobile.ViewModels
{
    public abstract class AuthorizedViewModel : BaseViewModel
    {
        public AuthorizedViewModel(IAuthenticationService authenticationService)
        {
            _authService = authenticationService;
        }

        private IAuthenticationService _authService;

        public bool IsAdmin => _authService.User.Role.Equals("Admin");
        public string UserName => _authService.User.UserName;
    }
}
