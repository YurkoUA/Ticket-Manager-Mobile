using System.Collections.Generic;
using System.Threading.Tasks;
using TicketApi.Extensions;
using TicketApi.Interfaces;
using TicketApi.Models;

namespace TicketApi.Services
{
    public class SerialService : ISerialService
    {
        private IHttpService _httpService;

        public SerialService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<IEnumerable<Serial>> GetSeriesAsync()
        {
            return await _httpService.Client.GetJsonAsync<IEnumerable<Serial>>("Serial/GetAll");
        }

        public async Task<Serial> GetByIdAsync(int id)
        {
            return await _httpService.Client.GetJsonAsync<Serial>($"Serial/Get/{id}");
        }

        public async Task<IEnumerable<Package>> GetPackagesAsync(int serialId)
        {
            return await _httpService.Client.GetJsonAsync<IEnumerable<Package>>($"Serial/GetPackages/{serialId}");
        }
    }
}
