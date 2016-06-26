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
using WebApplication.Models.DataModels;

namespace WebApplication.Controllers
{
    [Authorize]
    public class GenreController : Controller
    {
        private readonly IListService service;
        private readonly IBookService bookService;

        public GenreController(IListService service, IBookService bookService)
        {
            this.service = service;
            this.bookService = bookService;
        }

        // GET: Genre
        public ActionResult Index()
        {
            try
            {
                return View(Genre.GetGenreIndexModel());
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        // POST: Genre/Create
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(GenreModel genre)
        {
            try
            {
                if (ModelState.IsValid && service.GetAllGenres().All(e => e.Name != genre.Name))
                {
                    service.AddGenre(genre.ToServiceGenre());
                    if (Request.IsAjaxRequest())
                    {
                        return PartialView("_GenreTreeView", Genre.GetGenreIndexModel());
                    }
                    return RedirectToAction("Index");
                }
                if (Request.IsAjaxRequest())
                {
                    return PartialView("_GenreTreeView", Genre.GetGenreIndexModel());
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }
        }

        public ActionResult List(int id)
        {
            try
            {
                int userID = (int?) Profile["ID"] ?? 0;
                ServiceGenre genre = service.GetGenreById(id);
                var books = service.GetGenreBooks(genre);
                List<BookShortModel> list = books.Select(book => Book.GetBookShortModel(book.ID, userID)).ToList();

                return View(genre.ToGenreBookListModel(list));
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: Genre/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                var genre = service.GetGenreById(id);
                return View(genre.ToGenreModel());
            }
            catch
            {
                return View("Error");
            }
        }

        // POST: Genre/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteObject(int id)
        {
            try
            {
                ServiceGenre genre = service.GetGenreById(id);
                service.RemoveGenre(genre);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View("Error");
            }
        }
    }
}
