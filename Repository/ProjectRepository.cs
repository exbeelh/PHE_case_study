using SupplyManagement.Contract;
using SupplyManagement.Models;

namespace SupplyManagement.Repository
{
    public class ProjectRepository : GeneralRepository<Projects, string>, IProjectRepository
    {
        public ProjectRepository(SupplyManagementContext context) : base(context)
        {
        }
    }
}