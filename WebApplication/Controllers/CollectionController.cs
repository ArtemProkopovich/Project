using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NLog;
using Service.Interfacies;
using WebApplication.Infrastructure.Mappers;
using WebApplication.Models.CollectionBookModels;
using WebApplication.Models.CollectionModels;

namespace WebApplication.Controllers
{
    [Authorize]
    public class CollectionController : Controller
    {
        private readonly IServiceManager manager;
        private Logger logger = LogManager.GetCurrentClassLogger();
        public CollectionController(IServiceManager manager)
        {
            this.manager = manager;
        }
        // GET: Collection
        public ActionResult Index()
        {
            try
            {
                int userId = (int)Profile["ID"];
                return View(Models.DataModels.Collection.GetCollectionListModel(userId));
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return View("Error");
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            int userID = (int)Profile["ID"];
            return View(new CollectionModel() {UserID = userID});
        }

        [HttpPost]
        public ActionResult Create(CollectionModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    manager.collectionService.AddUserCollection(model.ToServiceCollection());
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return View("Error");
            }
        }
        [HttpGet]
        public ActionResult Clear(int id)
        {
            try
            {
                var cl = manager.collectionService.GetCollectionById(id);
                return View(cl.ToCollectionModel());
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return View("Error");
            }
        }
        [HttpPost]
        public ActionResult Clear(int id, FormCollection collection)
        {
            try
            {
                var cl = manager.collectionService.GetCollectionById(id);
                manager.collectionService.ClearCollection(cl);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return View("Error");
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            try
            {
                var cl = manager.collectionService.GetCollectionById(id);
                return View(cl.ToCollectionModel());
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult Edit(CollectionModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    manager.collectionService.UpdateCollection(model.ToServiceCollection());
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return View("Error");
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                var cl = manager.collectionService.GetCollectionById(id);
                return View(cl.ToCollectionModel());
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var cl = manager.collectionService.GetCollectionById(id);
                manager.collectionService.RemoveCollection(cl);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return View("Error");
            }
        }
    }
}