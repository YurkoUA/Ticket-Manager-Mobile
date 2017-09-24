using System.Collections.Generic;
using System.Threading.Tasks;
using TicketApi.Models;

namespace TicketApi.Interfaces
{
    public interface IColorService
    {
        Task<IEnumerable<Color>> GetColorsAsync();
        Task<Color> GetByIdAsync(int id);
        Task<IEnumerable<Package>> GetPackagesAsync(int colorId);
    }
}
