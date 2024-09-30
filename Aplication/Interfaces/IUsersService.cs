using Aplication.Request.Users;
using Aplication.Response.ApiResponse;

namespace Aplication.Interfaces
{
    public interface IUsersService
    {
        public ApiResponse CreateUser(CreateUserRequest request);
    }
}
