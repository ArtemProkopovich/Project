using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service.Interfacies;
using Service.Interfacies.Entities;
using WebApplication.Infrastructure.Mappers;
using WebApplication.Models.CollectionBookModels;
using WebApplication.Models.DataModels;

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

        public ActionResult Details(int id)
        {
            try
            {
                int userID = (int)Profile["ID"];
                var model = CollectionBook.GetCollectionBookPageModel(id, userID);
                return View(model);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
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

        public ActionResult Read(int ID)
        {
            try
            {
                return View(CollectionBook.GetReadBookModel(ID));
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        public ActionResult Download(int ID)
        {
            try
            {
                return View("");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }
        /*[HttpGet]
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
        }*/

        [HttpGet]
        public ActionResult DeleteFromCollection(int bookID, int clID, string returnUrl)
        {
            try
            {
                var cl = manager.collectionService.GetCollectionById(clID);
                var books = manager.collectionService.GetCollectionBooks(cl);
                var book = books.FirstOrDefault(e => e.BookID == bookID);
                return Delete(book?.ID ?? 0, returnUrl);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        [HttpGet]
        public ActionResult Delete(int ID, string returnUrl)
        {
            try
            {
                var clBook = manager.collectionService.GetCollectionBookById(ID);
                manager.collectionService.RemoveBook(clBook);
                if (Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                return RedirectToAction("Index", "Collection");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        public ActionResult GetFile(int ID)
        {
            var book = manager.bookService.GetBookById(ID);
            //ServiceFile file = manager.bookService.GetBookFiles(book)?.First();
            string filepath = Server.MapPath("~/App_Data/Uploads/Files/1.pdf");
                return new FileStreamResult(new FileStream(filepath, FileMode.Open, FileAccess.Read), "application/pdf");
        }
    }
}