using Domain.InterfaceRepository;
using Domain.Models;

namespace Infrastructure.Repository
{
    public class UsersRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UsersRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Users CreateUser(Users user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }
    }
}
