using System.Net;

namespace Aplication.Response.ApiResponse
{
    public class ApiResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
        public object Response { get; set; }

        public ApiResponse(HttpStatusCode statusCode, string message, object response)
        {
            StatusCode = statusCode;
            Message = message;
            Response = response;
        }
    }
}
