using System.Collections.Generic;
using System.Threading.Tasks;
using TicketApi.Models;

namespace TicketApi.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUserAsync();
        Task<Login> GetLastLoginAsync();
        Task<IEnumerable<Login>> GetLoginHistoryAsync();
    }
}
