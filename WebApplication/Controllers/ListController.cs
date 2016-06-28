using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NLog;
using Service.Interfacies;
using Service.Interfacies.Entities;
using WebApplication.Infrastructure.Mappers;
using WebApplication.Models;
using WebApplication.Models.BookModels;
using WebApplication.Models.DataModels;
using WebApplication.Models.UserModels;
using WebApplication.Models.ViewModels.ListModels;

namespace WebApplication.Controllers
{
    public class ListController : Controller
    {
        private readonly IListService service;
        private readonly IBookService bookService;
        private Logger logger = LogManager.GetCurrentClassLogger();
        public ListController(IListService service, IBookService bookService)
        {
            this.service = service;
            this.bookService = bookService;
        }
        // GET: List
        public ActionResult Index()
        {
            try
            {
                var model = Models.DataModels.List.GetListIndexModel();
                return View(model);
            }
            catch(Exception ex)
            {
                logger.Error(ex);
                return View("Error");
            }
        }

        // POST: List/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(ListModel list)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (service.GetAllLists().All(e => e.Name != list.Name))
                    {
                        service.AddList(list.ToServiceList());
                        if (Request.IsAjaxRequest())
                        {
                            var lim = Models.DataModels.List.GetListIndexModel();
                            return PartialView("_ListCoverListView", lim);
                        }
                        return RedirectToAction("Index");
                    }
                }
                return RedirectToAction("Index");
            }
            catch(Exception ex)
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

                EditListModel elm = Models.DataModels.List.GetEditListModel(id);
                return View(elm);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult Edit(EditListModel model)
        {
            try
            {
                ServiceList sl = new ServiceList();
                sl.ID = model.List.ID;
                sl.Name = model.List.Name;
                service.UpdateList(sl);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return View("Error");
            }
        }

        private class MyEqualityComparer : IEqualityComparer<ServiceBook>
        {
            public bool Equals(ServiceBook x, ServiceBook y)
            {
                return x.ID == y.ID;
            }

            public int GetHashCode(ServiceBook obj)
            {
                return obj.ID.GetHashCode() + obj.Name.GetHashCode();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult AddListBook(int listID, int bookID)
        {
            try
            {
                var sl = service.GetListById(listID);
                var sb = bookService.GetBookById(bookID);
                service.AddListBook(sl, sb);
                if (Request.IsAjaxRequest())
                {
                    return PartialView("_EditListView", Models.DataModels.List.GetEditListModel(listID));
                }
                return RedirectToAction("Edit", new {ID = listID});
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return View("Error");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles ="Admin")]
        public ActionResult DeleteListBook(int listID, int bookID)
        {
            try
            {
                var sl = service.GetListById(listID);
                var sb = bookService.GetBookById(bookID);
                service.RemoveListBook(sl, sb);
                if (Request.IsAjaxRequest())
                {
                    return PartialView("_EditListView", Models.DataModels.List.GetEditListModel(listID));
                }
                return RedirectToAction("Edit", new { ID = listID });
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return View("Error");
            }
        }

        public ActionResult List(int id)
        {
            try
            {
                int userID = (int)Profile["ID"];
                ListPageModel model = Models.DataModels.List.GetListPageModel(id, userID);
                return View(model);
            }
            catch(Exception ex)
            {
                logger.Error(ex);
                return View("Error");
            }
        }

        // GET: List/Delete/5
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            try
            {
                var list = service.GetListById(id);
                return View(list.ToListModel());
            }
            catch(Exception ex)
            {
                logger.Error(ex);
                return View("Error");
            }
        }

        // POST: List/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        [ActionName("Delete")]
        public ActionResult DeleteObject(int id)
        {
            try
            {
                ServiceList list = service.GetListById(id);
                service.RemoveList(list);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                logger.Error(ex);
                return View("Error");
            }
        }
    }
}
