using System.Net;

namespace Aplication.Response.ApiResponse
{
    public class OkHelper
    {
        public static ApiResponse CreateOkResponse<T>(HttpStatusCode httpStatusCode, string message, T data)
        {
            var okResponse = new ApiOkResponse<T>(data);
            return new ApiResponse(httpStatusCode, message, okResponse);
        }
    }
}
