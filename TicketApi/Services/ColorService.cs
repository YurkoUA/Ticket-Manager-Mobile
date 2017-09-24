using System.Collections.Generic;
using System.Threading.Tasks;
using TicketApi.Extensions;
using TicketApi.Interfaces;
using TicketApi.Models;

namespace TicketApi.Services
{
    public class ColorService : IColorService
    {
        private IHttpService _httpService;

        public ColorService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<IEnumerable<Color>> GetColorsAsync()
        {
            return await _httpService.Client.GetJsonAsync<IEnumerable<Color>>("Color/GetAll");
        }

        public async Task<Color> GetByIdAsync(int id)
        {
            return await _httpService.Client.GetJsonAsync<Color>($"Color/Get/{id}");
        }

        public async Task<IEnumerable<Package>> GetPackagesAsync(int colorId)
        {
            return await _httpService.Client.GetJsonAsync<IEnumerable<Package>>($"Color/GetPackages/{colorId}");
        }
    }
}
