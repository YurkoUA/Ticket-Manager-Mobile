using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketApi.Extensions;
using TicketApi.Interfaces;
using TicketApi.Models;

namespace TicketApi.Services
{
    public class UserService : IUserService
    {
        private IHttpService _httpService;

        public UserService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<User> GetUserAsync()
        {
            return await _httpService.Client.GetJsonAsync<User>("Account/Get");
        }

        public async Task<Login> GetLastLoginAsync()
        {
            return (await _httpService.Client.GetJsonAsync<IEnumerable<Login>>("Account/GetLoginHistory?take=10"))
                .FirstOrDefault();
        }

        public async Task<IEnumerable<Login>> GetLoginHistoryAsync()
        {
            return await _httpService.Client.GetJsonAsync<IEnumerable<Login>>("Account/GetLoginHistory");
        }
    }
}
