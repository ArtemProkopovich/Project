using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service.Interfacies;
using Service.Interfacies.Interfacies;
using WebApplication.Infrastructure.Mappers;
using WebApplication.Models.AuthorModels;

namespace WebApplication.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService service;

        public AuthorController(IAuthorService service)
        {
            this.service = service;
        }
        // GET: Author
        public ActionResult Index()
        {
            return View();
        }

        // GET: Author/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
                    model.Photo.SaveAs("filepath");
                    service.AddAuthor(model.ToServiceAuthor("filepath"));
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
                    model.NewPhoto.SaveAs("filepath");
                    model.PhothPath = "filepath";

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
