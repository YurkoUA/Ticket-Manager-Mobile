using Windows.Security.Credentials;
using TicketApi.Interfaces;
using TicketApi.Exceptions;
using TicketManagerMobile.Views.Account;
using TicketManagerMobile.Views.Home;
using static TicketManagerMobile.Util.AutofacConfig;

namespace TicketManagerMobile.ViewModels.Account
{
    public class TryAuthorizeViewModel : BaseViewModel
    {
        private IAuthenticationService _authService;
        private INavigationService _navigationService;
        private ICredentialService _credentialService;

        public TryAuthorizeViewModel(IAuthenticationService authService, INavigationService navigService, ICredentialService credentialService)
        {
            _authService = authService;
            _navigationService = navigService;
            _credentialService = credentialService;
        }

        public PasswordCredential GetCredential()
        {
            return Resolve<ICredentialService>().FindFirst();
        }

        public async void TryAuthorizeAsync(PasswordCredential credential)
        {
            var authService = Resolve<IAuthenticationService>();
            var credentialService = Resolve<ICredentialService>();

            try
            {
                credential.RetrievePassword();
                await authService.AuthorizeAsync(credential.UserName, credential.Password, false);
                authService.Credential = credential;

                _navigationService.NavigateTo(typeof(HomePage));
            }
            catch (BadRequestException)
            {
                credentialService.Remove(credential);
                _navigationService.NavigateTo(typeof(SignInPage));
            }
            catch
            {
                _navigationService.NavigateTo(typeof(SignInPage));
            }
        }
    }
}
