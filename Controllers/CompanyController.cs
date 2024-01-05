using SupplyManagement.Contract;
using SupplyManagement.Models;
using SupplyManagement.ViewModel.Company;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SupplyManagement.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IUserRepository _userRepository;

        public CompanyController(ICompanyRepository companyRepository, IUserRepository userRepository)
        {
            _companyRepository = companyRepository;
            _userRepository = userRepository;
        }


        [HttpGet]
        public ActionResult RegisterCompany()
        {
            var model = new RegisterCompanyViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterCompany(RegisterCompanyViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.PhotoFile != null && model.PhotoFile.ContentLength > 0)
                    {
                        using var binaryReader = new BinaryReader(model.PhotoFile.InputStream);
                        var entity = new Companies
                        {
                            Id = Guid.NewGuid().ToString(),
                            Email = model.Email,
                            Name = model.Name,
                            Phone = model.Phone,
                            ApprovalStatusId = 1,
                            // Map other properties...
                            Image = binaryReader.ReadBytes((int)model.PhotoFile.InputStream.Length),
                            UserId = model.User.Id,
                        };
                        _companyRepository.Create(entity);
                    }
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "An error occurred while processing your request.");
            }

            return View(model);
        }
    }
}