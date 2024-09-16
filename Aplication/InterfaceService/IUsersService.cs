using Aplication.Request.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.InterfaceService
{
    public interface IUsersService
    {
        public Guid CreateUser(CreateUserRequest request);
    }
}
