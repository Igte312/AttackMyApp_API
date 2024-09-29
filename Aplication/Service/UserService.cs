using Aplication.ErrorHandling;
using Aplication.InterfaceService;
using Aplication.Request.Users;
using Aplication.Response.ApiResponse;
using Aplication.Response.User;
using Domain.InterfaceRepository;
using Domain.Models;
using System.Net;

namespace Aplication.Service
{
    public class UserService : IUsersService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public ApiResponse CreateUser(CreateUserRequest request)
        {
            var newUser = NewUser(request);

            var createdUser = _userRepository.CreateUser(newUser);

            if (createdUser != null)
            {
                return ErrorHelper.CreateErrorResponse(HttpStatusCode.BadRequest, ErrorMessages.BadRequest, ErrorMessages.DbConnectionFailed);
            }

            var responseData = new UserCreateResponce
            {
                UserId = createdUser!.UserId,
            };

            return ResponseHelper.CreateResponse(HttpStatusCode.Created, OkMessages.Created, responseData);
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
