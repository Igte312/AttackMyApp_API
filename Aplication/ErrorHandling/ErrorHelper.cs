using Aplication.Response.ApiResponse;
using System.Net;

namespace Aplication.ErrorHandling
{
    public static class ErrorHelper
    {
        public static ApiResponse CreateErrorResponse(HttpStatusCode httpStatusCode,string message, ErrorDetail errorDetail)
        {
            var errorResponse = new ApiErrorResponse(errorDetail.Code, errorDetail.Message);
            return new ApiResponse(httpStatusCode, message, errorResponse);
        }
    }
}
