using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service.Interfacies;
using WebApplication.Infrastructure.Mappers;
using WebApplication.Models.CollectionBookModels;

namespace WebApplication.Controllers
{
    [Authorize]
    public class CollectionBookController : Controller
    {
        private readonly IServiceManager manager;
        public CollectionBookController(IServiceManager manager)
        {
            this.manager = manager;
        }

        // GET: CollectionBook
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add(int bookID, int clID, string returnUrl)
        {
            try
            {
                var dbBook = manager.bookService.GetBookById(bookID);
                var dbCl = manager.collectionService.GetCollectionById(clID);
                manager.collectionService.AddBook(dbCl, dbBook);
                if (Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                return RedirectToAction("Index", "Collection");
            }
            catch
            {
                return View("Error");
            }
        }

        public ActionResult Move(int ID, int clID)
        {
            try
            {
                var clBook = manager.collectionService.GetCollectionBookById(ID);
                var Cl = manager.collectionService.GetCollectionById(clID);
                manager.collectionService.MoveBook(clBook, Cl);
                return RedirectToAction("Index", "Collection");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        [HttpGet]
        public ActionResult Delete(int ID)
        {
            try
            {
                CollectionBookModel model = new CollectionBookModel();
                var clBook = manager.collectionService.GetCollectionBookById(ID);
                var cl = manager.collectionService.GetCollectionById(clBook.CollectionID);
                var book = manager.bookService.GetBookById(clBook.BookID);
                model = clBook.ToCollectionBookModel(book.ToBookShortModel(), cl.ToCollectionModel());
                return View(model);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult Delete(int ID, FormCollection collection)
        {
            try
            {
                var clBook = manager.collectionService.GetCollectionBookById(ID);
                manager.collectionService.RemoveBook(clBook);
                return RedirectToAction("Index", "Collection");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }
    }
}