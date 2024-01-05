using SupplyManagement.Contract;
using SupplyManagement.Handler;
using SupplyManagement.Models;
using SupplyManagement.ViewModel;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SupplyManagement.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        public UserController(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            if (ModelState.IsValid)
            {
                var user = new Users
                {
                    Id = Guid.NewGuid().ToString(),
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Password = Hashing.HashPassword(model.Password),
                    RoleId = 2
                };

                _userRepository.Register(user);

                return RedirectToAction("Login");
            }

            return View(model);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            if (ModelState.IsValid)
            {
                var user = _userRepository.Login(model.Email, model.Password);

                if (user != null)
                {
                    string userRole = GetUserRoleFromDatabase(user.Id);

                    FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                        1,
                        user.FirstName + " " + user.LastName,
                        DateTime.Now,
                        DateTime.Now.AddMinutes(30), // Adjust as needed
                        false,
                        userRole, // Store the role in userData
                        FormsAuthentication.FormsCookiePath
                    );

                    string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                    HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    Response.Cookies.Add(authCookie);
                    /*FormsAuthentication.SetAuthCookie(user.FirstName + " " + user.LastName, false);*/
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Email and password do not match");
            }

            return View(model);
        }

        private string GetUserRoleFromDatabase(string userId)
        {
            // Replace this with your logic to retrieve the user's role from the database
            // For example, if your user object has a RoleId property, you can convert it to role name
            int roleId = _userRepository.GetById(userId).RoleId.Value;

            // Assume you have a method to get role name by role id
            return _roleRepository.GetById(roleId).Name;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "User");
        }
    }
}