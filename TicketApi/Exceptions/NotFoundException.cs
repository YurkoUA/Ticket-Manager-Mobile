using System.Net.Http;

namespace TicketApi.Exceptions
{
    public class NotFoundException : HttpResponseException
    {
        public NotFoundException(HttpResponseMessage response) : base(response)
        {
        }
    }
}
