using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication.Models.UserModels;

namespace WebApplication.Controllers.Account
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View(new LoginModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(model.Login, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(Membership.GetUser(model.Login, true)?.UserName, true);

                    if (model.Remember)
                    {
                        const int timeout = 2880;
                        var ticket = new FormsAuthenticationTicket(model.Login, model.Remember, timeout);
                        string encrypted = FormsAuthentication.Encrypt(ticket);
                        var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted)
                        {
                            Expires = System.DateTime.Now.AddMinutes(timeout),
                            HttpOnly = true
                        };
                        HttpContext.Response.Cookies.Add(cookie);
                    }

                    //Управляет службами проверки подлинности с помощью форм для веб-приложений
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect login or password.");
                }
            }
            return View(model);
        }

        [Authorize]
        public ActionResult LogOff()
        {
            if (Request.Cookies[FormsAuthentication.FormsCookieName] != null)
            {
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName)
                {
                    Expires = DateTime.Now.AddDays(-1d)
                };
                Response.Cookies.Add(cookie);
            }
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Login");
        }

    }
}