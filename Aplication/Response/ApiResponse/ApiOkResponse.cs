
namespace Aplication.Response.ApiResponse
{
    public class ApiOkResponse<T>
    {
        public T Data { get; set; }

        public ApiOkResponse(T data)
        {
            Data = data;
        }
    }
}
