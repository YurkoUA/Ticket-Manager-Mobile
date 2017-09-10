using System;
using System.Net.Http;
using System.Net.Http.Headers;
using TicketApi.Interfaces;
using TicketApi.Models;

namespace TicketApi.Services
{
    public class HttpService : IHttpService
    {
        private HttpClient _client;
        private string _baseAddress;

        public HttpService(string baseAddress, string userAgent)
        {
            _baseAddress = baseAddress + "api/";

            _client = new HttpClient
            {
                BaseAddress = new Uri(BaseAddress)
            };

            _client.DefaultRequestHeaders.UserAgent.ParseAdd(userAgent);
        }

        public HttpClient Client => _client;

        public string BaseAddress => _baseAddress;

        public void ConfigureAuthorization(AccessToken token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token.TokenType, token.ToString());
        }

        public void ResetAuthorization()
        {
            _client.DefaultRequestHeaders.Authorization = null;
        }
    }
}
