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
            var books = manager.bookService.GetAllBooks().Take(4);
            var bookList = books.Select(book => manager.bookService.GetFullBookInfo(book.ID).ToBookShortModel()).ToList();
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

            List<ListFirstModel> listList = new List<ListFirstModel>();
            var lists = manager.listService.GetAllLists();
            foreach (var list in lists)
            {
                var book = manager.listService.GetListBooks(list).FirstOrDefault();
                if (book != null)
                {
                    var smb = book.ToBookShortModel();
                    smb.Cover = manager.bookService.GetBookCovers(book)?.FirstOrDefault()?.ImagePath;
                    listList.Add(new ListFirstModel() {book = smb, list = list.ToListModel()});
                }
            }
            BookIndexPageModel bipm = new BookIndexPageModel()
            {
                Authors = authorList,
                Books = bookList,
                Genres = genreList,
                Lists = listList
            };

            return View(bipm);
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
        public ActionResult Create()
        {
           try
           {
               var genres = manager.listService.GetAllGenres();
               var tags = manager.listService.GetAllTags();
               var authors = manager.authorService.GetAllAuthors();
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
                manager.bookService.AddBook(book);
                book = manager.bookService.GetBookByName(book.Name);
                ServiceTag tag = manager.listService.GetTagByName(model.Tag);
                ServiceGenre genre = manager.listService.GetGenreByName(model.Genre);
                ServiceAuthor author = manager.authorService.GetByName(model.Author);
                manager.authorService.AddAuthorBook(author, book);
                manager.listService.AddBookGenre(book, genre);
                manager.listService.AddBookTag(book, tag);
                if (model.Cover != null)
                {
                    ServiceCover cover = new ServiceCover();
                    string filepath = Server.MapPath("~/App_Data/Uploads/Covers/Books/" +
                                                     FilePathGenerator.GenerateFileName(model.Cover.FileName));
                    model.Cover.SaveAs(filepath);
                    cover.BookID = book.ID;
                    cover.ImagePath = filepath;
                    manager.bookService.AddCover(book, cover);
                }
                if (model.File != null)
                {
                    ServiceFile file = new ServiceFile();
                    string filepath = Server.MapPath("~/App_Data/Uploads/Files/" +
                                                     FilePathGenerator.GenerateFileName(model.File.FileName));
                    model.File.SaveAs(filepath);
                    file.BookID = book.ID;
                    file.Path = filepath;
                    manager.bookService.AddFile(book, file);
                }

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
                var book = manager.bookService.GetBookById(id);
                return View();
            }
            catch
            {
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult Edit(BookCreateModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return RedirectToAction("Details"/*, new {id = model.ID}*/);
                }
                return View();
            }
            catch
            {
                return View("Error");
            }
        }

        public ActionResult List()
        {
            try
            {
                var books = manager.bookService.GetAllBooks();
                var bookList = books.Select(book => manager.bookService.GetFullBookInfo(book.ID).ToBookShortModel()).ToList();
                return View(bookList);
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
            ServiceCover cover = manager.bookService.GetBookCovers(book)?.First();
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