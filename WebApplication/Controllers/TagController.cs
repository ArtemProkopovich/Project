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
    public class TagController : Controller
    {
        private readonly IListService service;

        public TagController(IListService service)
        {
            this.service = service;
        }
        // GET: Tag
        public ActionResult Index()
        {
            try
            {
                var tags =  service.GetAllTags().Select(e=>e.ToTagModel());
                return View(tags);
            }
            catch(Exception ex)
            {
                return View("Error");
            }          
        }

        // GET: Tag/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tag/Create
        [HttpPost]
        public ActionResult Create(TagModel model)
        {
            try
            {
                if (service.GetAllTags().All(e => e.Name != model.Name))
                {
                    service.AddTag(model.ToServiceTag());
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Tag/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var tag = service.GetTagById(id);
                return View(tag.ToTagModel());
            }
            catch
            {
                return View("Error");
            }
        }

        // POST: Tag/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteObject(int id)
        {
            try
            {
                ServiceTag tag = service.GetTagById(id);
                service.RemoveTag(tag);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
