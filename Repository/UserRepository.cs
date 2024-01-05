using SupplyManagement.Contract;
using SupplyManagement.Handler;
using SupplyManagement.Models;
using System.Linq;

namespace SupplyManagement.Repository
{
    public class UserRepository : GeneralRepository<Users, string>, IUserRepository
    {
        public UserRepository(SupplyManagementContext context) : base(context)
        {
        }

        public Users Login(string email, string password)
        {
            var user = _context.Set<Users>().FirstOrDefault(u => u.Email == email);

            if (user != null && Hashing.ValidatePassword(password, user.Password))
            {
                return user;
            }

            return null;
        }

        public void Register(Users user)
        {
            user.RoleId = 2; // Set the default role to 2

            _context.Set<Users>().Add(user);
            _context.SaveChanges();
        }

        public string GetRoleNameById(int? roleId)
        {
            var role = _context.Role.FirstOrDefault(r => r.Id == roleId);

            return role?.Name;
        }

        public int GetUserRole(string userId)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);

            return user?.RoleId ?? 0;
        }

        public Users GetUserByEmail(string email)
        {
            return _context.Set<Users>().FirstOrDefault(u => u.Email == email);
        }
    }
}