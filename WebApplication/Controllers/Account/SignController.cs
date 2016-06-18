using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Service.Interfacies;
using WebApplication.Models.UserModels;
using WebApplication.Providers;

namespace WebApplication.Controllers.Account
{
    [AllowAnonymous]
    public class SignController : Controller
    {

        private readonly IUserService userService;
        public SignController(IUserService userService)
        {
            this.userService = userService;
        }

        // GET: Sign
        [HttpGet]
        public ActionResult Sign()
        {
            return View(new SignModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Sign(SignModel model)
        {

            if (userService.GetUserByEmail(model.Email)!=null)
            {
                ModelState.AddModelError("", "User with this email already exists.");
                return View(model);
            }

            if (userService.GetUserByLogin(model.Login) != null)
            {
                ModelState.AddModelError("", "User with this login already exists.");
                return View(model);
            }

            if (ModelState.IsValid)
            {
                var membershipUser = ((CustomMembershipProvider) Membership.Provider).CreateUser(model.Login,
                    model.Email, model.Password);

                if (membershipUser != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Login, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Error registration.");
                }
            }
            return View(model);
        }
    }
}