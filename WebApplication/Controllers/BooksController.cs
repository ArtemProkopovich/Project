using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service.Interfacies;
using Service.Interfacies.Entities;
using Service.Interfacies.Interfacies;
using ServiceLibrary.Service;
using WebApplication.Infrastructure;
using WebApplication.Infrastructure.Mappers;
using WebApplication.Models.BookModels;

namespace WebApplication.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService service;
        private readonly IListService listService;
        private readonly IAuthorService authorService;

        public BooksController(IBookService service, IListService listService , IAuthorService authorService)
        {
            this.service = service;
            this.listService = listService;
            this.authorService = authorService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            try
            {
                BookPageModel model =  service.GetFullBookInfo(id).ServiceBookToModelBook();
                return View(model);
            }
            catch (ServiceException ex)
            {
                return View("Error");
            }
        }
        
       [HttpGet]
        public ActionResult Create()
        {
           try
           {
               var genres = listService.GetAllGenres();
               var tags = listService.GetAllTags();
               var authors = authorService.GetAllAuthors();
               List<SelectListItem> genresSL =
                   genres.Select(g => new SelectListItem() {Text = g.Name, Selected = false}).ToList();
               List<SelectListItem> tagsSL =
                   tags.Select(g => new SelectListItem() {Text = g.Name, Selected = false}).ToList();
                List<SelectListItem> authorsSL =
                   authors.Select(g => new SelectListItem() { Text = g.Name, Selected = false }).ToList();

                ViewData["genres"] = genresSL;
               ViewData["tags"] = tagsSL;
               ViewData["authors"] = authorsSL;
               return View();
           }
           catch
           {
               return View("Error");
           }
        }

        [HttpPost]
        public ActionResult Create(BookCreateModel model)
        {
            try
            {
                ServiceBook book = model.CreateModelToServiceBook();
                book.ID = service.AddBook(book);
                ServiceTag tag = listService.GetTagByName(model.Tag);
                ServiceGenre genre = listService.GetGenreByName(model.Genre);
                ServiceAuthor author = authorService.GetByName(model.Author);
                authorService.AddAuthorBook(author, book);
                if (model.Cover != null)
                {
                    ServiceCover cover = new ServiceCover();
                    string filepath = Server.MapPath("~/App_Data/Uploads/Covers/" +
                                                     FilePathGenerator.GenerateFileName(model.Cover.FileName));
                    model.Cover.SaveAs(filepath);
                    cover.BookID = book.ID;
                    cover.ImagePath = filepath;
                    service.AddCover(book, cover);
                }
                if (model.File != null)
                {
                    ServiceFile file = new ServiceFile();
                    string filepath = Server.MapPath("~/App_Data/Uploads/Files/" +
                                                     FilePathGenerator.GenerateFileName(model.File.FileName));
                    model.File.SaveAs(filepath);
                    file.BookID = book.ID;
                    file.Path = filepath;
                    service.AddFile(book, file);
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var book = service.GetBookById(id).ToBookShortModel();
                return View(book);
            }
            catch
            {
                return View("Error");
            }
        }

        // POST: Books/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var book = service.GetBookById(id);
                service.RemoveBook(book);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }
        }
    }
}