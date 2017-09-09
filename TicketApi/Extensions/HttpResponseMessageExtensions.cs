using System.Net;
using System.Net.Http;
using TicketApi.Exceptions;

namespace TicketApi.Extensions
{
    public static class HttpResponseMessageExtensions
    {
        public static void ThrowHttpResponseExceptions(this HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                if (response.StatusCode == HttpStatusCode.BadRequest)
                    throw new BadRequestException(response);
                else if (response.StatusCode == HttpStatusCode.NotFound)
                    throw new NotFoundException(response);
                else
                    throw new HttpResponseException(response);
            }
        }
    }
}
