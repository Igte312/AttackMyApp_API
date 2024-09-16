using Domain.Models;

namespace Domain.InterfaceRepository
{
    public interface IUserRepository
    {
        public Users CreateUser(Users user);
    }
}
