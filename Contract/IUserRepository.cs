using SupplyManagement.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyManagement.Contract
{
    public interface IUserRepository : IGeneralRepository<Users, string>
    {
        Users GetUserByEmail(string email);
        Users Login(string email, string password);
        void Register(Users user);
        int GetUserRole(string userId);
        string GetRoleNameById(int? roleId);
    }
}
