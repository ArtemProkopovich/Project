using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NLog;
using Service.Interfacies;
using Service.Interfacies.Entities;
using WebApplication.Infrastructure.Mappers;
using WebApplication.Models.DataModels;
using WebApplication.Models.ViewModels.FindModels;

namespace WebApplication.Controllers
{
    public class FindController : Controller
    {
        private readonly IServiceManager manager;
        private Logger logger = LogManager.GetCurrentClassLogger();
        public FindController(IServiceManager manager)
        {
            this.manager = manager;
        }
        // GET: Find
        public ActionResult Index(string text)
        {
            try
            {
                text = text.Trim(' ');
                if (text.Length > 2)
                {
                    IEnumerable<ServiceAuthor> authors =
                        manager.findService.FindByAuthor(text).OrderBy(e => e.Name).Take(5);
                    IEnumerable<ServiceBook> books = manager.findService.FindByBook(text).OrderBy(e => e.Name).Take(5);
                    return
                        View(new FindIndexModel()
                        {
                            Books = books.Select(Book.GetBookShortModel),
                            Authors = authors.Select(e => e.ToAuthorShortModel()),
                            Query = text
                        });
                }
                else
                {
                    var books = manager.bookService.OrderTake(ServiceOrderType.Likes, 0, 5);
                    var authors = manager.authorService.OrderTake(0, 5);
                    return
                        View(new FindIndexModel()
                        {
                            Books = books.Select(Book.GetBookShortModel),
                            Authors = authors.Select(e => e.ToAuthorShortModel()),
                            Query = text
                        });
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return View("Error");
            }
        }

        public JsonResult Find(string term)
        {
            try
            {
                term = term.Trim(' ');
                if (term.Length >= 2)
                {
                    IEnumerable<ServiceAuthor> authors =
                        manager.findService.FindByAuthor(term).OrderBy(e => e.Name).Take(5);
                    IEnumerable<ServiceBook> books = manager.findService.FindByBook(term).OrderBy(e => e.Name).Take(5);
                    var jsonResult =
                        authors.Select(
                            e => new {value = Url.Action("Details", "Author", new {id = e.ID}), label = e.Name});
                    jsonResult = jsonResult.Concat(
                        books.Select(e => new {value = Url.Action("Details", "Books", new {id = e.ID}), label = e.Name}));
                    return Json(jsonResult, JsonRequestBehavior.AllowGet);
                }
                return Json("Bad query", JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                logger.Error(ex);
                return Json("Bad query", JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult FindBook(string term)
        {
            try
            {
                term = term.Trim(' ');
                if (term.Length >= 2)
                {
                    IEnumerable<ServiceBook> books = manager.findService.FindByBook(term).OrderBy(e => e.Name).Take(5);
                    var jsonResult =
                        books.Select(e => new {value = e.ID, label = e.Name});
                    return Json(jsonResult, JsonRequestBehavior.AllowGet);
                }
                return Json("Bad query", JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                logger.Error(ex);
                return Json("Bad query", JsonRequestBehavior.AllowGet);
            }
        }
    }
}