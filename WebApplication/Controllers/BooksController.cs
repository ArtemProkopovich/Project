using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service.Interfacies;
using ServiceLibrary.Service;

namespace WebApplication.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService service;

        public BooksController(IBookService service)
        {
            this.service = service;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            try
            {
                service.GetFullBookInfo(id);
                return View();
            }
            catch (ServiceException ex)
            {
                return View("Error");
            }
        }
    }
}