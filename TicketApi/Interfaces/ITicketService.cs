using System.Collections.Generic;
using System.Threading.Tasks;
using TicketApi.Models;

namespace TicketApi.Interfaces
{
    public interface ITicketService
    {
        Task<TicketsCount> GetCountAsync();

        Task<IEnumerable<Ticket>> GetTicketsAsync(int skip, int take);
        Task<IEnumerable<Ticket>> GetHappyTicketsAsync(int skip, int take);
        Task<IEnumerable<Ticket>> GetUnallocatedTicketsAsync(int skip, int take);

        Task<IEnumerable<Ticket>> GetClonesAsync();
        Task<IEnumerable<Ticket>> GetLatestTicketsAsync();

        Task<IEnumerable<Ticket>> SearchAsync(string number);
        Task<IEnumerable<Ticket>> ClonesWithAsync(int ticketId);

        Task<Ticket> GetByIdAsync(int id);
    }
}
