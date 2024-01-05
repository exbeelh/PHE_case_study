using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SupplyManagement.Models
{
    public partial class ProjectVendor
    {
        public string ProjectId { get; set; }
        public string CompanyId { get; set; }

        public virtual Companies Company { get; set; }
        public virtual Projects Project { get; set; }
    }
}
