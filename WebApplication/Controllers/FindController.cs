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
        public ActionResult Index(string query)
        {
            ViewBag.Query = query;
            return View();
        }
    }
}