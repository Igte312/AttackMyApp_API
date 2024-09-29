using Domain.InterfaceRepository;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class UserTypeRepository : IUserTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public UserTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public UserType CreateUserType(UserType userType)
        {
            _context.UserType.Add(userType);
            _context.SaveChanges();

            return userType;
        }
    }
}
