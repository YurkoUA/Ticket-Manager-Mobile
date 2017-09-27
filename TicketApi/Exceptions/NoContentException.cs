using System.Net.Http;

namespace TicketApi.Exceptions
{
    public class NoContentException : HttpResponseException
    {
        public NoContentException(HttpResponseMessage response) : base(response)
        {
        }
    }
}
