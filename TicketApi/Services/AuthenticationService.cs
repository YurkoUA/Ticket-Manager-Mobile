using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Windows.Security.Credentials;
using Newtonsoft.Json;
using TicketApi.Exceptions;
using TicketApi.Extensions;
using TicketApi.Interfaces;
using TicketApi.Models;

namespace TicketApi.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private IHttpService _httpService;
        private ICredentialService _credentialService;
        private IUserService _userService;

        private AccessToken _token;
        private User _user;
        private PasswordCredential _credential;

        public AuthenticationService(IHttpService httpService, ICredentialService credentialService, IUserService userService)
        {
            _httpService = httpService;
            _credentialService = credentialService;
            _userService = userService;
        }

        public bool IsAuthenticated => _token != null && _user != null;

        public AccessToken AccessToken => _token;

        public User User => _user;

        public PasswordCredential Credential => _credential;

        public async Task AuthorizaAsync(string userName, string password, bool isRemember)
        {
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(_httpService.BaseAddress + "token"),
                Method = HttpMethod.Post,
                Content = new StringContent($"grant_type=password&username={userName}&password={password}")
            };
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");

            var response = await _httpService.Client.SendAsync(request);
            response.ThrowHttpResponseExceptions();

            _token = JsonConvert.DeserializeObject<AccessToken>(await response.Content.ReadAsStringAsync());

            if (_token == null)
                throw new HttpResponseException(response);

            _user = await _userService.GetUserAsync();

            if (_user == null)
                throw new HttpResponseException(response);

            if (isRemember)
            {
                _credential = _credentialService.Save(userName, password);
            }
        }

        public void Logout()
        {
            if (!IsAuthenticated)
                return;

            _token = null;
            _user = null;

            _httpService.ResetAuthorization();

            if (_credential != null)
                _credentialService.Remove(_credential);
        }
    }
}
