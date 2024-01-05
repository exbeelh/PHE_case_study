using SupplyManagement.Contract;
using SupplyManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupplyManagement.Repository
{
    public class RoleRepository : GeneralRepository<Role, int>, IRoleRepository
    {
        public RoleRepository(SupplyManagementContext context) : base(context)
        {
        }
    }
}