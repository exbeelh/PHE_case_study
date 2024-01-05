using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SupplyManagement.Models
{
    public partial class CompanyDetails
    {
        public string CompanyId { get; set; }
        public int? BusinessFieldId { get; set; }
        public int? CompanyTypeId { get; set; }

        public virtual BusinessFields BusinessField { get; set; }
        public virtual Companies Company { get; set; }
        public virtual CompanyTypes CompanyType { get; set; }
    }
}
