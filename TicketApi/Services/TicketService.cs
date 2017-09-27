using System.Collections.Generic;
using System.Threading.Tasks;
using TicketApi.Extensions;
using TicketApi.Interfaces;
using TicketApi.Models;

namespace TicketApi.Services
{
    public class TicketService : ITicketService
    {
        private IHttpService _httpService;

        public TicketService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<TicketsCount> GetCountAsync()
        {
            return await _httpService.Client.GetJsonAsync<TicketsCount>("Ticket/GetCount");
        }

        public async Task<IEnumerable<Ticket>> GetTicketsAsync(int skip, int take)
        {
            return await _httpService.Client.GetJsonAsync<IEnumerable<Ticket>>($"Ticket/GetAll?skip={skip}&take={take}");
        }

        public async Task<IEnumerable<Ticket>> GetHappyTicketsAsync(int skip, int take)
        {
            return await _httpService.Client.GetJsonAsync<IEnumerable<Ticket>>($"Ticket/Happy?skip={skip}&take={take}");
        }

        public async Task<IEnumerable<Ticket>> GetUnallocatedTicketsAsync(int skip, int take)
        {
            return await _httpService.Client.GetJsonAsync<IEnumerable<Ticket>>($"Ticket/Unallocated?skip={skip}&take={take}");
        }

        public async Task<IEnumerable<Ticket>> GetClonesAsync()
        {
            return await _httpService.Client.GetJsonAsync<IEnumerable<Ticket>>("Ticket/Clones");
        }

        public async Task<IEnumerable<Ticket>> GetLatestTicketsAsync()
        {
            return await _httpService.Client.GetJsonAsync<IEnumerable<Ticket>>("Ticket/Latest");
        }

        public async Task<IEnumerable<Ticket>> SearchAsync(string number)
        {
            return await _httpService.Client.GetJsonAsync<IEnumerable<Ticket>>($"Ticket/Search?number={number}&partialMatches=True");
        }

        public async Task<IEnumerable<Ticket>> ClonesWithAsync(int ticketId)
        {
            return await _httpService.Client.GetJsonAsync<IEnumerable<Ticket>>($"Ticket/ClonesWith/{ticketId}");
        }

        public async Task<Ticket> GetByIdAsync(int id)
        {
            return await _httpService.Client.GetJsonAsync<Ticket>($"Ticket/Get/{id}");
        }
    }
}
