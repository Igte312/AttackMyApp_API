
namespace Aplication.ErrorHandling
{
    public static class ErrorMessages
    {
        //Encoded
        public static readonly ErrorDetail DbConnectionFailed = new ErrorDetail(001, "Failed to insert data due to a database connection issue.");


        //global http
        public const string BadRequest = "Bad Request";
    }
}
