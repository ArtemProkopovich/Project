using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
        public CollectionController(IServiceManager manager)
        {
            this.manager = manager;
        }
        // GET: Collection
        public ActionResult Index()
        {
            try
            {
                int userId = (int?) Profile["ID"] ?? 0;
                var user = manager.userService.GetUserByLogin(User.Identity.Name) ?? manager.userService.GetUserByEmail(User.Identity.Name);
                var profile = manager.userService.GetUserProfile(user.ID);
                var userCollections = manager.collectionService.GetUserCollections(user).OrderBy(e => e.Name);
                List<CollectionBookListModel> collectionsBooks = new List<CollectionBookListModel>();
                foreach (var cl in userCollections)
                {
                    CollectionBookListModel collectionBooksModel = new CollectionBookListModel();
                    collectionBooksModel.collection = cl.ToCollectionModel();
                    List<CollectionBookModel> books = new List<CollectionBookModel>();
                    var collcetionBooks = manager.collectionService.GetCollectionBooks(cl);
                    foreach (var book in collcetionBooks)
                    {
                        var shortBook = manager.bookService.GetFullBookInfo(book.BookID).ToBookShortModel(userId);
                        books.Add(book.ToCollectionBookModel(shortBook, collectionBooksModel.collection));
                    }
                    collectionBooksModel.books = books;
                    collectionsBooks.Add(collectionBooksModel);
                }
                return View(new CollectionListModel(profile, collectionsBooks));
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            var user = manager.userService.GetUserByLogin(User.Identity.Name) ?? manager.userService.GetUserByEmail(User.Identity.Name);
            return View(new CollectionModel() {UserID = user.ID});
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
                return View("Error");
            }
        }
    }
}