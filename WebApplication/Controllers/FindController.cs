using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service.Interfacies;

namespace WebApplication.Controllers
{
    public class FindController : Controller
    {
        private readonly IFindService service;

        public FindController(IFindService service)
        {
            this.service = service;
        }
        // GET: Find
        public ActionResult Index(string text)
        {
            ViewBag.Query = text;
            return View();
        }

        public JsonResult Find(string term)
        {
            try
            {
                List<string> result = new List<string>() {"12", "22", "32", "45"};
                var r = result.Select(e => new {id = e});
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new {label = "text"}, JsonRequestBehavior.AllowGet);
            }
        }
    }
}