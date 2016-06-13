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
                var tags =  service.GetAllTags().Select(e=>e.ToTagModel());
                return View(tags);
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
                ServiceTag tag = service.GetTagById(id);
                var books = service.GetTagBooks(tag);
                List<BookShortModel> list = new List<BookShortModel>();
                foreach (var book in books)
                {
                    BookShortModel bsm = book.ToBookShortModel();
                    bsm.Author = bookService.GetBookAuthors(book).FirstOrDefault().ToAuthorShortModel();
                    IEnumerable<ServiceLike> likes = bookService.GetBookLikes(book);
                    bsm.Likes = likes.Count(e => e.Like);
                    bsm.Dislikes = likes.Count(e => e.Like);
                    list.Add(bsm);
                }

                return View(tag.ToTagBookListModel(list));
            }
            catch
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
