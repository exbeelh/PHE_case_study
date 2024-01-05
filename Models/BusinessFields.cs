using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SupplyManagement.Models
{
    public partial class BusinessFields
    {
        public BusinessFields()
        {
            CompanyDetails = new HashSet<CompanyDetails>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CompanyDetails> CompanyDetails { get; set; }
    }
}
