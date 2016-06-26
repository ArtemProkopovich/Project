using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service.Interfacies;
using Service.Interfacies.Entities;
using WebApplication.Infrastructure.Mappers;
using WebApplication.Models;
using WebApplication.Models.BookModels;
using WebApplication.Models.DataModels;

namespace WebApplication.Controllers
{
    public class TagController : Controller
    {
        private readonly IListService service;
        private readonly IBookService bookService;

        public TagController(IListService service, IBookService bookService)
        {
            this.service = service;
            this.bookService = bookService;
        }
        // GET: Tag
        public ActionResult Index()
        {
            try
            {
                var model = Tag.GetTagIndexModel();
                return View(model);
            }
            catch(Exception ex)
            {
                return View("Error");
            }          
        }

        public ActionResult List(int id)
        {
            try
            {
                int userID = (int?) Profile["ID"] ?? 0;
                ServiceTag tag = service.GetTagById(id);
                var books = service.GetTagBooks(tag);
                List<BookShortModel> list = books.Select(book => Book.GetBookShortModel(book.ID, userID)).ToList();

                return View(tag.ToTagBookListModel(list));
            }
            catch
            {
                return View("Error");
            }
        }

        // POST: Tag/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TagModel tag)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (service.GetAllTags().All(e => e.Name != tag.Name))
                    {
                        service.AddTag(tag.ToServiceTag());
                        if (Request.IsAjaxRequest())
                        {
                            return PartialView("_TagTableView", Tag.GetTagIndexModel());
                        }
                        return RedirectToAction("Index");
                    }
                }
                if (Request.IsAjaxRequest())
                {
                    return PartialView("_TagTableView", Tag.GetTagIndexModel());
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: Tag/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var tag = service.GetTagById(id);
                return View(Tag.GetTagModel(id));
            }
            catch
            {
                return View("Error");
            }
        }

        // POST: Tag/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
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
