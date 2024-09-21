using Aplication.Request.Users;

namespace Aplication.InterfaceService
{
    public interface IUsersService
    {
        public Guid CreateUser(CreateUserRequest request);
    }
}
