using System.Collections.Generic;
using System.Threading.Tasks;
using TicketApi.Models;

namespace TicketApi.Interfaces
{
    public interface ISerialService
    {
        Task<IEnumerable<Serial>> GetSeriesAsync();
        Task<Serial> GetByIdAsync(int id);
        Task<IEnumerable<Package>> GetPackagesAsync(int serialId);
    }
}
