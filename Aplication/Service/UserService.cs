using Aplication.InterfaceService;
using Aplication.Request.Users;
using Domain.InterfaceRepository;
using Domain.Models;

namespace Aplication.Service
{
    public class UserService : IUsersService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Guid  CreateUser(CreateUserRequest request)
        {
            if (request == null)
            {
                throw new Exception("Request cannot be null");
            }

            if (string.IsNullOrEmpty(request.FirstName) ||
                string.IsNullOrEmpty(request.LastName) ||
                string.IsNullOrEmpty(request.Email))
            {
                throw new Exception("All fields are required.");
            }

            var newUser = NewUser(request);

            var user = _userRepository.CreateUser(newUser);

            return user.UserId;
        }

        private Users NewUser(CreateUserRequest user) 
        {
            var newUser = new Users
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
            };

            return newUser;
        }
    }
}
