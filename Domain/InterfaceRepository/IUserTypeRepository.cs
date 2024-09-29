using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.InterfaceRepository
{
    public interface IUserTypeRepository
    {
        public UserType CreateUserType(UserType userType);
    }
}
