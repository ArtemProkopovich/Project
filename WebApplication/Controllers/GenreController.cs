using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service.Interfacies.Entities;
using Service.Interfacies.Interfacies;
using WebApplication.Infrastructure.Mappers;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class GenreController : Controller
    {
        private readonly IListService service;

        public GenreController(IListService service)
        {
            this.service = service;
        }

        // GET: Genre
        public ActionResult Index()
        {
            try
            {
                var genres = service.GetAllGenres().Select(e => e.ToGenreModel());
                return View(genres);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        // GET: Genre/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Genre/Create
        [HttpPost]
        public ActionResult Create(GenreModel model)
        {
            try
            {
                if (service.GetAllGenres().All(e => e.Name != model.Name))
                {
                    service.AddGenre(model.ToServiceGenre());
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: Genre/Delete/5
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
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                ServiceGenre genre = service.GetGenreById(id);
                service.RemoveGenre(genre);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
