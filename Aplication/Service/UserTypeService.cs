using Aplication.ErrorHandling;
using Aplication.InterfaceService;
using Aplication.Request.Users;
using Aplication.Response.ApiResponse;
using Domain.InterfaceRepository;
using Domain.Models;
using System.Net;

namespace Aplication.Service
{
    public class UserTypeService : IUserTypeService
    {
        private readonly IUserTypeRepository _userTypeRepository;

        public UserTypeService(IUserTypeRepository userTypeRepository)
        {
            _userTypeRepository = userTypeRepository;
        }

        public ApiResponse CreateUserType(CreateUserTypeRequest request)
        {
            var newUserType = new UserType
            {
               SiegfriedType = request.SiegfriedType,
            };

            var createdUserType = _userTypeRepository.CreateUserType(newUserType);

            if (createdUserType == null)
            {
                return ErrorHelper.CreateErrorResponse(HttpStatusCode.BadRequest, ErrorMessages.BadRequest, ErrorMessages.DbConnectionFailed);
            }

            return ResponseHelper.CreateResponse(HttpStatusCode.Created, OkMessages.Created, createdUserType);
        }
    }
}
