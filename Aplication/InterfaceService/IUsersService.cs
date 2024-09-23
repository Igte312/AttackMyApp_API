using Aplication.Request.Users;
using Aplication.Response.ApiResponse;

namespace Aplication.InterfaceService
{
    public interface IUsersService
    {
        public ApiResponse CreateUser(CreateUserRequest request);
    }
}
