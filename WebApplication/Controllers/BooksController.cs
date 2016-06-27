using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service.Interfacies;
using Service.Interfacies.Entities;
using ServiceLibrary.Service;
using WebApplication.Infrastructure;
using WebApplication.Infrastructure.Mappers;
using WebApplication.Models;
using WebApplication.Models.AuthorModels;
using WebApplication.Models.BookModels;
using WebApplication.Models.DataModels;
using WebApplication.Models.ViewModels.BookModels;
using WebApplication.Models.ViewModels.ListModels;

namespace WebApplication.Controllers
{
    public class BooksController : Controller
    {
        private readonly IServiceManager manager;

        public BooksController(IServiceManager manager)
        {
            this.manager = manager;
        }

        public ActionResult Index()
        {
            try
            {
                int userID = (int?) Profile["ID"] ?? 0;
                var books = manager.bookService.GetAllBooks().Take(4);
                var bookList =
                    books.Select(book => manager.bookService.GetFullBookInfo(book.ID).ToBookShortModel(userID)).ToList();
                IEnumerable<AuthorShortModel> authorList =
                    manager.authorService.GetAllAuthors().Take(4).Select(e => e.ToAuthorShortModel());
                var genres = manager.listService.GetAllGenres();
                List<GenreFirstModel> genreList = new List<GenreFirstModel>();
                foreach (var genre in genres)
                {
                    var book = manager.listService.GetGenreBooks(genre).FirstOrDefault();
                    if (book != null)
                    {
                        var smb = book.ToBookShortModel();
                        smb.Cover = manager.bookService.GetBookCovers(book)?.FirstOrDefault()?.ImagePath;
                        genreList.Add(new GenreFirstModel() {book = smb, genre = genre.ToGenreModel()});
                    }
                }


                BookIndexPageModel bipm = new BookIndexPageModel()
                {
                    Authors = authorList,
                    Books = bookList,
                    Genres = genreList,
                    Lists = new List<ListShortModel>()
                };

                return View(bipm);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        public ActionResult Random()
        {
            try
            {
                ServiceBook book = manager.bookService.GetRandomBook();
                BookPageModel model = manager.bookService.GetFullBookInfo(book.ID).ServiceBookToModelBook();
                return View("Details", model);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        public ActionResult Details(int id)
        {
            try
            {
                int userID = 0;
                if (User.Identity.IsAuthenticated)
                {
                    userID = (int) Profile["ID"];
                }
                BookPageModel model = Book.GetBookPageModel(id, userID);
                return View(model);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }
        
       [HttpGet]
       [Authorize]
        public ActionResult Create()
        {
           try
           {
               return View(Book.GetBookCreateModel());
           }
           catch
           {
               return View("Error");
           }
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookCreateModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int userID = (int)Profile["ID"];
                    int id = Book.SaveBook(model, userID, Server);
                    return RedirectToAction("Details", id);
                }
                var bcm = Book.GetBookCreateModel();
                model.AuthorList = bcm.AuthorList;
                model.GenreList = bcm.GenreList;
                model.TagList = bcm.TagList;
                return View(model);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        [HttpGet]
        [Authorize]
        public ActionResult Edit(int id)
        {
            try
            {
                var model = Book.GetBookEditModel(id);
                return View(model);
            }
            catch
            {
                return View("Error");
            }
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BookEditModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Book.UpdateBook(model);
                    return RedirectToAction("Details", new {id = model.ID});
                }
                var bcm = Book.GetBookCreateModel();
                model.AuthorList = bcm.AuthorList;
                model.GenreList = bcm.GenreList;
                model.TagList = bcm.TagList;
                return View(model);
            }
            catch(Exception ex)
            {
                return View("Error");
            }
        }

        public ActionResult List()
        {
            try
            {
                int userID = (int) Profile["ID"];
                var model = Book.GetBookListModel(SortBy.Likes, 20, 1, userID);
                return View(model);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        [ActionName("FilterList")]
        public ActionResult List(SortBy filter, int booksOnPage)
        {
            try
            {
                int userID = (int)Profile["ID"];
                var model = Book.GetBookListModel(filter, booksOnPage, 1, userID);
                if (Request.IsAjaxRequest())
                {
                    return PartialView("_BookListNavView", model);
                }
                else
                {
                    return View("List", model);
                }
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }


        [ActionName("FilterListPage")]
        public ActionResult List(SortBy filter, int booksOnPage, int currentPage)
        {
            try
            {
                int userID = (int) Profile["ID"];
                var model = Book.GetBookListModel(filter, booksOnPage, currentPage, userID);
                if (Request.IsAjaxRequest())
                {
                    return PartialView("_BookListPartialView", model);
                }
                else
                {
                    return View("List", model);
                }
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        // GET: Books/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            try
            {
                var book = manager.bookService.GetBookById(id).ToBookShortModel();
                return View(book);
            }
            catch
            {
                return View("Error");
            }
        }

        // POST: Books/Delete/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var book = manager.bookService.GetBookById(id);
                manager.bookService.RemoveBook(book);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }
        }

        public FileResult GetImage(int id)
        {
            var book = manager.bookService.GetBookById(id);
            ServiceCover cover = manager.bookService.GetBookCovers(book)?.FirstOrDefault();
            return cover != null
                ? new FilePathResult(cover.ImagePath, "image/*")
                : new FilePathResult(Server.MapPath("~/App_Data/Uploads/Covers/Books/" + "no_book_cover.jpg"), "image/*");
        }

        [Authorize]
        public ActionResult DownloadFile(int id, int fileID)
        {
            var book = manager.bookService.GetBookById(id);
            var file = manager.bookService.GetBookFiles(book).FirstOrDefault(e => e.ID == fileID);
            if (file != null)
                return new FilePathResult(file.Path, "");
            return View("Error");
        }
    }
}