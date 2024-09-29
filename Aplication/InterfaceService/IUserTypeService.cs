using Aplication.Request.Users;
using Aplication.Response.ApiResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.InterfaceService
{
    public interface IUserTypeService
    {
        public ApiResponse CreateUserType(CreateUserTypeRequest request);
    }
}
