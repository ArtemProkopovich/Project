using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service.Interfacies;
using Service.Interfacies.Interfacies;
using WebApplication.Infrastructure;
using WebApplication.Infrastructure.Mappers;
using WebApplication.Models.AuthorModels;
using System.IO;
using System.Text;
using Service.Interfacies.Entities;
using WebApplication.Models.BookModels;

namespace WebApplication.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService service;
        private readonly IBookService bookService;

        public AuthorController(IAuthorService service, IBookService bookService)
        {
            this.service = service;
            this.bookService = bookService;
        }
        // GET: Author
        public ActionResult Index()
        {
            try
            {
                var authors = service.GetAllAuthors().Select(e=>e.ToAuthorShortModel());
                return View(authors);
            }
            catch
            {
                return View("Error");
            }
        }

        //GET: Author/Details/5
        public ActionResult Details(int id)
        {
            ServiceFullAuthor sfa  = service.GetFullAuthorInfo(id);
            AuthorFullModel author = sfa.ToAuthorFullModel();
            List<BookShortModel> list = new List<BookShortModel>();
            foreach (var book in sfa.AuthorBooks)
            {
                BookShortModel bsm = book.ToBookShortModel();
                bsm.Author = sfa.AuthorData.ToAuthorShortModel();
                IEnumerable<ServiceLike> likes = bookService.GetBookLikes(book);
                bsm.Likes = likes.Count(e => e.Like);
                bsm.Dislikes = likes.Count(e => e.Like);
                list.Add(bsm);
            }
            author.Books = list;
            return View(author);
        }

        // GET: Author/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Author/Create
        [HttpPost]
        public ActionResult Create(AuthorCreateModel model)
        {
            try
            {
                if (model.Photo != null)
                {
                    string filepath = Server.MapPath("~/App_Data/Uploads/Covers/" +
                                                     FilePathGenerator.GenerateFileName(model.Photo.FileName));
                    model.Photo.SaveAs(filepath);
                    service.AddAuthor(model.ToServiceAuthor(filepath));
                }
                else
                    service.AddAuthor(model.ToServiceAuthor());
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
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
            catch
            {
                return View("Error");
            }
        }

        // POST: Author/Edit/5
        [HttpPost]
        public ActionResult Edit(AuthorEditModel model)
        {
            try
            {
                if (model.NewPhoto != null)
                {
                    string filepath = Server.MapPath("~/App_Data/Uploads/Covers" +
                                                     FilePathGenerator.GenerateFileName(model.NewPhoto.FileName));
                    if (!string.IsNullOrEmpty(model.PhothPath) && System.IO.File.Exists(model.PhothPath))
                        System.IO.File.Delete(model.PhothPath);
                    model.NewPhoto.SaveAs(filepath);
                    model.PhothPath = filepath;

                }
                var author = model.ToServiceAuthor();
                service.UpdateAuthor(author);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Author/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var author = service.GetById(id).ToAuthorShortModel();
                return View(author);
            }
            catch
            {
                return View("Error");
            }
        }

        // POST: Author/Delete/5
        [HttpPost]
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
            catch
            {
                return View("Error");
            }
        }
    }
}
