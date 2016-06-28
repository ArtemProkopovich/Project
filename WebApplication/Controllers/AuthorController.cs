using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service.Interfacies;
using WebApplication.Infrastructure;
using WebApplication.Infrastructure.Mappers;
using WebApplication.Models.AuthorModels;
using System.IO;
using System.Text;
using System.Web.Routing;
using NLog;
using Service.Interfacies.Entities;
using WebApplication.Models.BookModels;
using WebApplication.Models.DataModels;

namespace WebApplication.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService service;
        private readonly IBookService bookService;
        private Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public AuthorController(IAuthorService service, IBookService bookService)
        {
            this.service = service;
            this.bookService = bookService;
        }

        private const int BooksOnPage=8;

        // GET: Author
        public ActionResult Index()
        {
            try
            {
                var model = Author.GetAuthorIndexModel(BooksOnPage, 1);
                return View(model);
            }
            catch(Exception ex)
            {
                logger.Error(ex);
                return View("Error");
            }
        }

        public ActionResult List(int currentPage)
        {
            try
            {
                var model = Author.GetAuthorIndexModel(BooksOnPage, currentPage);
                if (Request.IsAjaxRequest())
                {
                    return PartialView("_AuthorListView", model);
                }
                return View("Index", model);
            }
            catch(Exception ex)
            {
                logger.Error(ex);
                return View("Error");
            }
        }

        //GET: Author/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                int userID = (int?) Profile["ID"] ?? 0;
                ServiceFullAuthor sfa = service.GetFullAuthorInfo(id);
                AuthorFullModel author = sfa.ToAuthorFullModel();
                List<BookShortModel> list =
                    sfa.AuthorBooks.Select(book => Book.GetBookShortModel(book.ID, userID)).ToList();
                author.Books = list;
                return View(author);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return View("Error");
            }
        }

        // GET: Author/Create
        [Authorize(Roles ="Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Author/Create
        [HttpPost]
        [Authorize(Roles ="Admin")]
        public ActionResult Create(AuthorCreateModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int id;
                    if (model.Photo != null)
                    {
                        string filepath = Server.MapPath("~/App_Data/Uploads/Covers/Authors/" +
                                                         FilePathGenerator.GenerateFileName(model.Photo.FileName));
                        model.Photo.SaveAs(filepath);
                        id = service.AddAuthor(model.ToServiceAuthor(filepath));
                    }
                    else
                        id = service.AddAuthor(model.ToServiceAuthor());
                    return RedirectToAction("Details", new {id = id});
                }
                return View(model);
            }
            catch(Exception ex)
            {
                logger.Error(ex);
                return View("Error");
            }
        }

        // GET: Author/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var author = service.GetById(id).ToAuthorEditModel();
                return View(author);
            }
            catch(Exception ex)
            {
                logger.Error(ex);
                return View("Error");
            }
        }

        // POST: Author/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AuthorEditModel model)
        {
            try
            {
                if (model.NewPhoto != null)
                {
                    string filepath = Server.MapPath("~/App_Data/Uploads/Covers/Authors/" +
                                                     FilePathGenerator.GenerateFileName(model.NewPhoto.FileName));
                    if (!string.IsNullOrEmpty(model.PhotoPath) && System.IO.File.Exists(model.PhotoPath))
                        System.IO.File.Delete(model.PhotoPath);
                    model.NewPhoto.SaveAs(filepath);
                    model.PhotoPath = filepath;

                }
                var author = model.ToServiceAuthor();
                service.UpdateAuthor(author);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                logger.Error(ex);
                return View("Error");
            }
        }

        // GET: Author/Delete/5
        [Authorize(Roles ="Admin")]
        public ActionResult Delete(int id)
        {
            try
            {
                var author = service.GetById(id).ToAuthorShortModel();
                return View(author);
            }
            catch(Exception ex)
            {
                logger.Error(ex);
                return View("Error");
            }
        }

        // POST: Author/Delete/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var author = service.GetById(id);
                if (!string.IsNullOrEmpty(author.Photo) && System.IO.File.Exists(author.Photo))
                    System.IO.File.Delete(author.Photo);
                service.RemoveAuthor(author);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                logger.Error(ex);
                return View("Error");
            }
        }

        
        public FileResult GetImage(int id)
        {
            try
            {
                var author = service.GetById(id);
                return !string.IsNullOrEmpty(author?.Photo)
                    ? new FilePathResult(author.Photo, "image/*")
                    : new FilePathResult(Server.MapPath("~/App_Data/Uploads/Covers/Authors/" + "no_author_cover.png"),
                        "image/*");
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }
    }
}
