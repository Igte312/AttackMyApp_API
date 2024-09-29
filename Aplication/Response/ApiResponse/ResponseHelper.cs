using System.Net;

namespace Aplication.Response.ApiResponse
{
    public class ResponseHelper
    {
        public static ApiResponse CreateResponse<T>(HttpStatusCode httpStatusCode, string message, T data)
        {
            var okResponse = new ApiOkResponse<T>(data);
            return new ApiResponse(httpStatusCode, message, okResponse);
        }
    }
}
