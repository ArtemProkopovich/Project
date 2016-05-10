using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models.UserModels;

namespace WebApplication.Controllers.Account
{
    public class SignController : Controller
    {
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
            return View(model);
        }
    }
}