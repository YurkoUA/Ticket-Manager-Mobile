using System.Net.Http;

namespace TicketApi.Exceptions
{
    public class UnauthorizedException : HttpResponseException
    {
        public UnauthorizedException(HttpResponseMessage response) : base(response)
        {
        }
    }
}
