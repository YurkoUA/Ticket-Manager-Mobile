using System.Threading.Tasks;
using Windows.Security.Credentials;
using TicketApi.Models;

namespace TicketApi.Interfaces
{
    public interface IAuthenticationService
    {
        bool IsAuthenticated { get; }
        AccessToken AccessToken { get; }
        User User { get; }
        PasswordCredential Credential { get; }

        Task AuthorizaAsync(string userName, string password, bool isRemember);
        void Logout();
    }
}
