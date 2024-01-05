using SupplyManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyManagement.Contract
{
    public interface IProjectRepository : IGeneralRepository <Projects, string>
    {
    }
}
