
namespace Aplication.ErrorHandling
{
    public class ApiErrorResponse
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }

        public ApiErrorResponse(int errorCode, string errorMessage)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
        }
    }
}
