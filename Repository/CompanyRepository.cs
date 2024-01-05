using SupplyManagement.Contract;
using SupplyManagement.Models;

namespace SupplyManagement.Repository
{
    public class CompanyRepository : GeneralRepository<Companies, string>, ICompanyRepository
    {
        public CompanyRepository(SupplyManagementContext context) : base(context)
        {
        }
    }
}