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

            if (createdUser == null)
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
            var newPass = new Siegfried
            {
                Email = user.Email,
                Password = user.Password,
                SiegfriedTypeId = Guid.Parse("0f28cd27-21c9-4cf9-b8c7-8c439db12e86"),
                CreationDate = DateTime.Now,
            };

            var newUser = new Users
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                CreationDate = DateTime.Now,
                Siegfried = newPass,
            };

            return newUser;
        }
    }
}
