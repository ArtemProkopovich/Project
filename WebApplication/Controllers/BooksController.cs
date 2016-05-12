using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service.Interfacies;
using Service.Interfacies.Entities;
using Service.Interfacies.Interfacies;
using ServiceLibrary.Service;
using WebApplication.Infrastructure.Mappers;
using WebApplication.Models.BookModels;

namespace WebApplication.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService service;
        private readonly IListService listService;

        public BooksController(IBookService service, IListService listService)
        {
            this.service = service;
            this.listService = listService;
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
                List<SelectListItem> genresSL = genres.Select(g => new SelectListItem() {Text = g.Name, Selected = false}).ToList();
                List<SelectListItem> tagsSL = tags.Select(g => new SelectListItem() { Text = g.Name, Selected = false }).ToList();

                ViewData["genres"] =  genresSL;
                ViewData["tags"] = tagsSL;
                return View();
           }
           catch
           {
               return View("Error");
           }
        }

        [HttpPost]
        [ActionName("Create")]
        public ActionResult CreateObject(BookCreateModel model)
        {
            try
            {
                ServiceBook book = model.CreateModelToServiceBook();
                book.ID = service.AddBook(book);
                ServiceTag tag = listService.GetTagByName(model.Tag);
                ServiceGenre genre = listService.GetGenreByName(model.Genre);
               

                RedirectToAction("Details", book.ID);
            }
            catch(Exception ex)
            {
                return View("Error");
            }
            return View();
        }
    }
}