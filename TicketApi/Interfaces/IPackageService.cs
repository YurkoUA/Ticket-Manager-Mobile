using System.Collections.Generic;
using System.Threading.Tasks;
using TicketApi.Enums;
using TicketApi.Models;

namespace TicketApi.Interfaces
{
    public interface IPackageService
    {
        Task<PackagesCount> GetCount();

        Task<IEnumerable<Package>> GetPackagesAsync(int skip, int take, PackagesFilter filter);
        Task<Package> GetByIdAsync(int id);
        Task<IEnumerable<Package>> SearchAsync(string name);

        Task<IEnumerable<Ticket>> GetTicketsAsync(int packageId);
        Task<IEnumerable<Ticket>> GetUnallocatedTicketsAsync(int packageId);
    }
}
