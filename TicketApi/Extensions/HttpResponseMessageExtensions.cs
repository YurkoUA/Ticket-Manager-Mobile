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
                switch (response.StatusCode)
                {
                    case HttpStatusCode.BadRequest:
                        throw new BadRequestException(response);
                    case HttpStatusCode.NotFound:
                        throw new NotFoundException(response);
                    case HttpStatusCode.Unauthorized:
                        throw new UnauthorizedException(response);

                    default:
                        throw new HttpResponseException(response);
                }
            }
        }
    }
}
