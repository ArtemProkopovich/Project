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
using WebApplication.Models.UserModels;

namespace WebApplication.Controllers
{
    public class ListController : Controller
    {
        private readonly IListService service;
        private readonly IBookService bookService;

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
                var lists = service.GetAllLists().Select(e=>e.ToListModel());
                return View(lists);
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: List/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: List/Create
        [HttpPost]
        public ActionResult Create(ListModel model)
        {
            try
            {
                if (service.GetAllLists().All(e => e.Name != model.Name))
                {
                    service.AddList(model.ToServiceList());
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            try
            {
                ServiceList list = service.GetListById(id);
                var books = service.GetListBooks(list);
                var allBooks = bookService.GetAllBooks();
                allBooks = allBooks.Except(books, new MyEqualityComparer());
                List<BookShortModel> bookList = new List<BookShortModel>();
                foreach (var book in books)
                {
                    BookShortModel bsm = book.ToBookShortModel();
                    bsm.Author = bookService.GetBookAuthors(book).FirstOrDefault().ToAuthorShortModel();
                    bookList.Add(bsm);
                }
                List<BookShortModel> otherBookList = new List<BookShortModel>();
                foreach (var book in allBooks)
                {
                    BookShortModel bsm = book.ToBookShortModel();
                    bsm.Author = bookService.GetBookAuthors(book).FirstOrDefault().ToAuthorShortModel();
                    otherBookList.Add(bsm);
                }
                EditListModel elm = new EditListModel()
                {
                    List = list.ToListModel(),
                    ListBooks = bookList,
                    OtherBooks = otherBookList
                };
                return View(elm);
            }
            catch (Exception ex)
            {
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

        [HttpGet]
        public ActionResult AddListBook(int listID, int bookID)
        {
            try
            {
                var sl = service.GetListById(listID);
                var sb = bookService.GetBookById(bookID);
                service.AddListBook(sl, sb);
                return RedirectToAction("Edit", new {ID = listID});
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        [HttpGet]
        public ActionResult DeleteListBook(int listID, int bookID)
        {
            try
            {
                var sl = service.GetListById(listID);
                var sb = bookService.GetBookById(bookID);
                service.RemoveListBook(sl, sb);
                return RedirectToAction("Edit", new { ID = listID });
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        public ActionResult List(int id)
        {
            try
            {
                ServiceList list = service.GetListById(id);
                var books = service.GetListBooks(list);
                List<BookShortModel> bookList = new List<BookShortModel>();
                foreach (var book in books)
                {
                    BookShortModel bsm = book.ToBookShortModel();
                    bsm.Author = bookService.GetBookAuthors(book).FirstOrDefault().ToAuthorShortModel();
                    IEnumerable<ServiceLike> likes = bookService.GetBookLikes(book);
                    bsm.Likes = likes.Count(e => e.Like);
                    bsm.Dislikes = likes.Count(e => e.Like);
                    bookList.Add(bsm);
                }

                return View(list.ToListBookListModel(bookList));
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: List/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var list = service.GetListById(id);
                return View(list.ToListModel());
            }
            catch
            {
                return View("Error");
            }
        }

        // POST: List/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteObject(int id)
        {
            try
            {
                ServiceList list = service.GetListById(id);
                service.RemoveList(list);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }
        }
    }
}
