using System;
using System.Net;
using System.Net.Http;

namespace TicketApi.Exceptions
{
    public class HttpResponseException : Exception
    {
        public HttpResponseException(HttpResponseMessage response)
        {
            Response = response;
        }

        public HttpResponseMessage Response { get; set; }
        public HttpStatusCode StatusCode => Response.StatusCode;
        public int StatusCodeNumber => (int)StatusCode;
    }
}
