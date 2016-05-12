using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service.Interfacies.Entities;
using Service.Interfacies.Interfacies;
using WebApplication.Infrastructure.Mappers;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class ListController : Controller
    {
        private readonly IListService service;

        public ListController(IListService service)
        {
            this.service = service;
        }
        // GET: List
        public ActionResult Index()
        {
            try
            {
                var lists = service.GetAllLists().Select(e=>e.ToListModel());
                return View(lists);
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: List/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: List/Create
        [HttpPost]
        public ActionResult Create(ListModel model)
        {
            try
            {
                if (service.GetAllLists().All(e => e.Name != model.Name))
                {
                    service.AddList(model.ToServiceList());
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: List/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var list = service.GetListById(id);
                return View(list.ToListModel());
            }
            catch
            {
                return View("Error");
            }
        }

        // POST: List/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteObject(int id)
        {
            try
            {
                ServiceList list = service.GetListById(id);
                service.RemoveList(list);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }
        }
    }
}
