using Aplication.Request.Users;
using Aplication.Response.ApiResponse;

namespace Aplication.Interfaces
{
    public interface IUserTypeService
    {
        public ApiResponse CreateUserType(CreateUserTypeRequest request);
    }
}
