using SupplyManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SupplyManagement.ViewModel.Company
{
    public class RegisterCompanyViewModel
    {
        public string Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Name { get; set; }

        [Phone]
        public string Phone { get; set; }

        [Display(Name = "Upload Photo")]
        public HttpPostedFileBase PhotoFile { get; set; }

        [Display(Name = "Approval Status")]
        public int? ApprovalStatusId { get; set; }

        [Display(Name = "User ID")]
        public string UserId { get; set; }

        public virtual Status ApprovalStatus { get; set; }

        public virtual Users User { get; set; }

        public virtual CompanyDetails CompanyDetails { get; set; }

        public virtual ICollection<ProjectVendor> ProjectVendor { get; set; }
    }
}