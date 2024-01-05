using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SupplyManagement.Models
{
    public partial class Companies
    {
        public Companies()
        {
            ProjectVendor = new HashSet<ProjectVendor>();
        }

        public string Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public byte[] Image { get; set; }
        public int? ApprovalStatusId { get; set; }
        public string UserId { get; set; }

        public virtual Status ApprovalStatus { get; set; }
        public virtual Users User { get; set; }
        public virtual CompanyDetails CompanyDetails { get; set; }
        public virtual ICollection<ProjectVendor> ProjectVendor { get; set; }
    }
}
