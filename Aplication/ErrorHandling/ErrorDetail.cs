
namespace Aplication.ErrorHandling
{
    public class ErrorDetail
    {
        public int Code { get; set; }
        public string Message { get; set; }

        public ErrorDetail(int code, string message)
        {
            Code = code;
            Message = message;
        }
    }
}
