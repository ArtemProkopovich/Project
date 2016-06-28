using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NLog;
using Service.Interfacies;
using Service.Interfacies.Entities;
using ServiceLibrary.Service;
using WebApplication.Infrastructure;
using WebApplication.Infrastructure.Mappers;
using WebApplication.Models;
using WebApplication.Models.AuthorModels;
using WebApplication.Models.BookModels;
using WebApplication.Models.DataModels;
using WebApplication.Models.ViewModels.BookModels;
using WebApplication.Models.ViewModels.ListModels;

namespace WebApplication.Controllers
{
    public class BooksController : Controller
    {
        private Logger logger = LogManager.GetCurrentClassLogger();
        private readonly IServiceManager manager;

        public BooksController(IServiceManager manager)
        {
            this.manager = manager;
        }

        public ActionResult Index()
        {
            try
            {
                return View(Book.GetBookIndexPageModel());
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return View("Error");
            }
        }

        public ActionResult Random()
        {
            try
            {
                int userID = (int)Profile["ID"];
                int booksCount = manager.bookService.GetAllBooksCount();
                List<BookModel> books = new List<BookModel>();
                var book =
                    manager.bookService.OrderTake(ServiceOrderType.Likes, RandomInit.GetRandom().Next(booksCount), 1)
                        .FirstOrDefault();

                return View("Details", Book.GetBookPageModel(book.ID, userID));
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return View("Error");
            }
        }

        public ActionResult Details(int id)
        {
            try
            {
                int userID = 0;
                if (User.Identity.IsAuthenticated)
                {
                    userID = (int) Profile["ID"];
                }
                BookPageModel model = Book.GetBookPageModel(id, userID);
                return View(model);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return View("Error");
            }
        }
        
       [HttpGet]
       [Authorize]
        public ActionResult Create()
        {
           try
           {
               return View(Book.GetBookCreateModel());
           }
           catch(Exception ex)
           {
                logger.Error(ex);
                return View("Error");
           }
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookCreateModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int userID = (int)Profile["ID"];
                    int id = Book.SaveBook(model, userID, Server);
                    return RedirectToAction("Details", new {id = id});
                }
                var bcm = Book.GetBookCreateModel();
                model.AuthorList = bcm.AuthorList;
                model.GenreList = bcm.GenreList;
                model.TagList = bcm.TagList;
                return View(model);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return View("Error");
            }
        }

        [HttpGet]
        [Authorize]
        public ActionResult Edit(int id)
        {
            try
            {
                var model = Book.GetBookEditModel(id);
                return View(model);
            }
            catch(Exception ex)
            {
                logger.Error(ex);
                return View("Error");
            }
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BookEditModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Book.UpdateBook(model);
                    return RedirectToAction("Details", new {id = model.ID});
                }
                var bcm = Book.GetBookCreateModel();
                model.AuthorList = bcm.AuthorList;
                model.GenreList = bcm.GenreList;
                model.TagList = bcm.TagList;
                return View(model);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return View("Error");
            }
        }

        public ActionResult List()
        {
            try
            {
                int userID = (int) Profile["ID"];
                var model = Book.GetBookListModel(SortBy.Likes, 6, 1, userID);
                return View(model);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return View("Error");
            }
        }

        [ActionName("FilterList")]
        public ActionResult List(SortBy filter, int booksOnPage)
        {
            try
            {
                int userID = (int)Profile["ID"];
                var model = Book.GetBookListModel(filter, booksOnPage, 1, userID);
                if (Request.IsAjaxRequest())
                {
                    return PartialView("_BookListNavView", model);
                }
                else
                {
                    return View("List", model);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return View("Error");
            }
        }


        [ActionName("FilterListPage")]
        public ActionResult List(SortBy filter, int booksOnPage, int currentPage)
        {
            try
            {
                int userID = (int) Profile["ID"];
                var model = Book.GetBookListModel(filter, booksOnPage, currentPage, userID);
                if (Request.IsAjaxRequest())
                {
                    return PartialView("_BookListPartialView", model);
                }
                else
                {
                    return View("List", model);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return View("Error");
            }
        }

        // GET: Books/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            try
            {
                var book = manager.bookService.GetBookById(id).ToBookShortModel();
                return View(book);
            }
            catch(Exception ex)
            {
                logger.Error(ex);
                return View("Error");
            }
        }

        // POST: Books/Delete/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var book = manager.bookService.GetBookById(id);
                manager.bookService.RemoveBook(book);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                logger.Error(ex);
                return View("Error");
            }
        }

        [HttpGet]
        public ActionResult UploadFile(int id)
        {
            try
            {
                var model = Book.GetBookFileEditModel(id);
                return View("FileEdit", model);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return View("Error");
            }
        }

        [HttpPost]
        public JsonResult UploadFile(int id, HttpPostedFileBase File)
        {
            try
            {
                var book = manager.bookService.GetBookById(id);
                if (book != null && File != null)
                {
                    string path = Models.DataModels.File.SaveFile(Server, File, "~/App_Data/Uploads/Files/");
                    manager.bookService.AddFile(book,
                        new ServiceFile() {BookID = id, Path = path, Format = Path.GetExtension(path)});
                }
                return Json(new {initialPreview = new {}, initialPreviewConfig = new {}, append = true});
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return Json(new {error = "Error loading file" });
            }
        }

        [HttpPost]
        public JsonResult UploadCover(int id, HttpPostedFileBase Cover)
        {
            try
            {
                var book = manager.bookService.GetBookById(id);
                if (book != null && Cover != null)
                {
                    string path = Models.DataModels.File.SaveFile(Server, Cover, "~/App_Data/Uploads/Covers/Books/");
                    manager.bookService.AddCover(book,
                        new ServiceCover() {BookID = id, ImagePath = path});
                }
                return Json(new { initialPreview = new { }, initialPreviewConfig = new { }, append = true });
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return Json(new { error = "Error loading file" });
            }
        }

        [HttpPost]
        public JsonResult DeleteFile(int bookID, int key)
        {
            try
            {
                var book = manager.bookService.GetBookById(bookID);
                var file = manager.bookService.GetBookFiles(book).FirstOrDefault(e => e.ID == key);
                if (file != null)
                    manager.bookService.RemoveFile(file);
                return Json(new { initialPreview = new { }, initialPreviewConfig = new { }, append = true });
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return Json(new { error = "Error loading file" });
            }
        }

        [HttpPost]
        public JsonResult DeleteCover(int bookID, int key)
        {
            try
            {
                var book = manager.bookService.GetBookById(bookID);
                var cover = manager.bookService.GetBookCovers(book).FirstOrDefault(e => e.ID == key);
                if (cover != null)
                    manager.bookService.RemoveCover(cover);
                return Json(new { initialPreview = new { }, initialPreviewConfig = new { }, append = true });
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return Json(new { error = "Error loading file" });
            }
        }

        public FileResult GetImage(int id)
        {
            try
            {
                var book = manager.bookService.GetBookById(id);
                ServiceCover cover = manager.bookService.GetBookCovers(book)?.FirstOrDefault();
                return cover != null
                    ? new FilePathResult(cover.ImagePath, "image/*")
                    : new FilePathResult(Server.MapPath("~/App_Data/Uploads/Covers/Books/" + "no_book_cover.jpg"),
                        "image/*");
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }

        public FileResult GetCover(int bookID, int coverID)
        {
            try
            {
                var book = manager.bookService.GetBookById(bookID);
                ServiceCover cover = manager.bookService.GetBookCovers(book)?.FirstOrDefault(e => e.ID == coverID);
                return cover != null
                    ? new FilePathResult(cover.ImagePath, "image/*")
                    : new FilePathResult(Server.MapPath("~/App_Data/Uploads/Covers/Books/" + "no_book_cover.jpg"),
                        "image/*");
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }

        [Authorize]
        public ActionResult GetFile(int bookID, int fileID)
        {
            try
            {
                var book = manager.bookService.GetBookById(bookID);
                var file = manager.bookService.GetBookFiles(book)?.FirstOrDefault(e => e.ID == fileID);
                if (fileID == 0)
                    file = manager.bookService.GetBookFiles(book)?.FirstOrDefault();
                if (file != null)
                    return new FilePathResult(file.Path, "application/pdf");

                return
                    new FilePathResult(Server.MapPath("~/App_Data/Uploads/Files/" + "pdf-sample.pdf"),
                        "application/pdf");
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return View("Error");
            }
        }
    }
}