using System.Net.Http;
using TicketApi.Models;

namespace TicketApi.Interfaces
{
    public interface IHttpService
    {
        HttpClient Client { get; }
        string BaseAddress { get; }

        void ConfigureAuthorization(AccessToken token);
        void ResetAuthorization();
    }
}
