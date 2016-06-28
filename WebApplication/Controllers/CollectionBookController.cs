using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NLog;
using Service.Interfacies;
using Service.Interfacies.Entities;
using WebApplication.Infrastructure.Mappers;
using WebApplication.Models.CollectionBookModels;
using WebApplication.Models.DataModels;
using WebApplication.Models.ViewModels.ContentModels;

namespace WebApplication.Controllers
{
    [Authorize]
    public class CollectionBookController : Controller
    {
        private readonly IServiceManager manager;
        private Logger logger = LogManager.GetCurrentClassLogger();
        public CollectionBookController(IServiceManager manager)
        {
            this.manager = manager;
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
                logger.Error(ex);
                return View("Error");
            }
        }
        [HttpPost]
        [Authorize]
        public ActionResult Add(int bookID, int clID, string returnUrl)
        {
            try
            {
                var dbBook = manager.bookService.GetBookById(bookID);
                var dbCl = manager.collectionService.GetCollectionById(clID);
                manager.collectionService.AddBook(dbCl, dbBook);
                if (Request.IsAjaxRequest())
                {
                    return PartialView("_CollectionsBookManageView", CollectionBook.GetBookInCollectionModel(bookID,
                        (int) Profile["ID"]));
                }
                if (Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                return RedirectToAction("Index", "Collection");
            }
            catch(Exception ex)
            {
                logger.Error(ex);
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
                logger.Error(ex);
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
                logger.Error(ex);
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
                logger.Error(ex);
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

        [HttpPost]
        [Authorize]
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
                logger.Error(ex);
                return View("Error");
            }
        }

        [HttpGet]
        [Authorize]
        public ActionResult Delete(int ID, string returnUrl)
        {
            try
            {
                var clBook = manager.collectionService.GetCollectionBookById(ID);
                manager.collectionService.RemoveBook(clBook);
                if (Request.IsAjaxRequest())
                {
                    return PartialView("_CollectionsBookManageView", CollectionBook.GetBookInCollectionModel(clBook.BookID,
                        (int)Profile["ID"]));
                }
                if (Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                return RedirectToAction("Index", "Collection");
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return View("Error");
            }
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult AddQuote(QuoteModel quote)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    manager.collectionService.AddQuote(quote.ToServiceQuote());
                    var model = Quote.GetQuoteList(quote.CollectionBookID);
                    if (Request.IsAjaxRequest())
                    {
                        return PartialView("_QuoteListView", model);
                    }
                    else
                    {
                        return RedirectToAction("Details", new { id = quote.CollectionBookID });
                    }
                }
                return RedirectToAction("Details", new {id = quote.CollectionBookID});
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return View("Error");
            }
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult AddBookmark(BookmarkModel bookmark)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    manager.collectionService.AddBookmark(bookmark.ToServiceBookmark());
                    var model = Bookmark.GetBookmarkList(bookmark.CollectionBookID);
                    if (Request.IsAjaxRequest())
                    {
                        return PartialView("_BookmarkListView", model);
                    }
                    else
                    {
                        return RedirectToAction("Details", new { id = bookmark.CollectionBookID });
                    }
                }
                return RedirectToAction("Details", new { id = bookmark.CollectionBookID });
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return View("Error");
            }
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult DeleteQuote(int quoteID)
        {
            try
            {
                var quote = manager.collectionService.GetQuote(quoteID);
                manager.collectionService.RemoveQuote(quote);
                if (Request.IsAjaxRequest())
                {
                    var model = Quote.GetQuoteList(quote.CollectionBookID);
                    return PartialView("_QuoteListView", model);
                }
                return RedirectToAction("Details", quote.CollectionBookID);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return View("Error");
            }
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult DeleteBookmark(int bookmarkID)
        {
            try
            {
                var bm = manager.collectionService.GetBookmark(bookmarkID);
                manager.collectionService.RemoveBookmark(bm);
                if (Request.IsAjaxRequest())
                {
                    var model = Bookmark.GetBookmarkList(bm.CollectionBookID);
                    return PartialView("_BookmarkListView", model);
                }
                return RedirectToAction("Details", bm.CollectionBookID);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return View("Error");
            }
        }

        public ActionResult GetFile(int ID)
        {
            try
            {
                var book = manager.bookService.GetBookById(ID);
                //ServiceFile file = manager.bookService.GetBookFiles(book)?.First();
                string filepath = Server.MapPath("~/App_Data/Uploads/Files/1.pdf");
                return new FileStreamResult(new FileStream(filepath, FileMode.Open, FileAccess.Read), "application/pdf");
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }
    }
}