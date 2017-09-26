using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketApi.Enums;
using TicketApi.Extensions;
using TicketApi.Interfaces;
using TicketApi.Models;

namespace TicketApi.Services
{
    public class PackageService : IPackageService
    {
        private IHttpService _httpService;

        public PackageService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<IEnumerable<Package>> GetPackagesAsync(int skip, int take, PackagesFilter filter)
        {
            return await _httpService.Client.GetJsonAsync<IEnumerable<Package>>($"/Package/GetAll?skip={skip}&take={take}&filter={filter}");
        }

        public async Task<Package> GetByIdAsync(int id)
        {
            return await _httpService.Client.GetJsonAsync<Package>($"/Package/Get/{id}");
        }

        public async Task<IEnumerable<Package>> SearchAsync(string name)
        {
            return await _httpService.Client.GetJsonAsync<IEnumerable<Package>>($"/Package/Search?name={name}");
        }

        public async Task<IEnumerable<Ticket>> GetTicketsAsync(int packageId)
        {
            return await _httpService.Client.GetJsonAsync<IEnumerable<Ticket>>($"/Package/GetTickets/{packageId}");
        }

        public async Task<IEnumerable<Ticket>> GetUnallocatedTicketsAsync(int packageId)
        {
            return await _httpService.Client.GetJsonAsync<IEnumerable<Ticket>>($"/Package/GetUnallocatedTickets/{packageId}");
        }
    }
}
