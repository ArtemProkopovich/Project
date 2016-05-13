using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service.Interfacies;
using Service.Interfacies.Entities;
using Service.Interfacies.Interfacies;
using ServiceLibrary.Service;
using WebApplication.Infrastructure;
using WebApplication.Infrastructure.Mappers;
using WebApplication.Models;
using WebApplication.Models.AuthorModels;
using WebApplication.Models.BookModels;

namespace WebApplication.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService service;
        private readonly IListService listService;
        private readonly IAuthorService authorService;

        public BooksController(IBookService service, IListService listService , IAuthorService authorService)
        {
            this.service = service;
            this.listService = listService;
            this.authorService = authorService;
        }

        public ActionResult Index()
        {
            
            var books = service.GetAllBooks().Take(4);
            var bookList = new List<BookShortModel>();
            foreach (var book in books)
            {
                BookShortModel bsm = book.ToBookShortModel();
                bsm.Author = service.GetBookAuthors(book)?.FirstOrDefault()?.ToAuthorShortModel();
                IEnumerable<ServiceLike> likes = service.GetBookLikes(book);
                bsm.Cover = service.GetBookCovers(book)?.First().ImagePath;
                bsm.Likes = likes.Count(e => e.Like);
                bsm.Dislikes = likes.Count(e => e.Like);
                bookList.Add(bsm);
            }
            IEnumerable<AuthorShortModel> authorList =
                authorService.GetAllAuthors().Take(4).Select(e => e.ToAuthorShortModel());
            var genres = listService.GetAllGenres();
            List<GenreFirstModel> genreList = new List<GenreFirstModel>();
            foreach (var genre in genres)
            {
                var book = listService.GetGenreBooks(genre).FirstOrDefault();
                var smb = book.ToBookShortModel();
                smb.Cover = service.GetBookCovers(book)?.FirstOrDefault()?.ImagePath;
                genreList.Add(new GenreFirstModel() {book = smb, genre = genre.ToGenreModel()});
            }

            List<ListFirstModel> listList = new List<ListFirstModel>();
            var lists = listService.GetAllLists();
            foreach (var list in lists)
            {
                var book = listService.GetListBooks(list).FirstOrDefault();
                var smb = book.ToBookShortModel();
                smb.Cover = service.GetBookCovers(book)?.FirstOrDefault()?.ImagePath;
                listList.Add(new ListFirstModel() {book = smb, list = list.ToListModel()});
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
                ServiceBook book = service.GetRandomBook();
                BookPageModel model = service.GetFullBookInfo(book.ID).ServiceBookToModelBook();
                return View("Details", model);
            }
            catch (ServiceException ex)
            {
                return View("Error");
            }
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
               var authors = authorService.GetAllAuthors();
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
                service.AddBook(book);
                book = service.GetBookByName(book.Name);
                ServiceTag tag = listService.GetTagByName(model.Tag);
                ServiceGenre genre = listService.GetGenreByName(model.Genre);
                ServiceAuthor author = authorService.GetByName(model.Author);
                authorService.AddAuthorBook(author, book);
                listService.AddBookGenre(book, genre);
                listService.AddBookTag(book, tag);
                if (model.Cover != null)
                {
                    ServiceCover cover = new ServiceCover();
                    string filepath = Server.MapPath("~/App_Data/Uploads/Covers/" +
                                                     FilePathGenerator.GenerateFileName(model.Cover.FileName));
                    model.Cover.SaveAs(filepath);
                    cover.BookID = book.ID;
                    cover.ImagePath = filepath;
                    service.AddCover(book, cover);
                }
                if (model.File != null)
                {
                    ServiceFile file = new ServiceFile();
                    string filepath = Server.MapPath("~/App_Data/Uploads/Files/" +
                                                     FilePathGenerator.GenerateFileName(model.File.FileName));
                    model.File.SaveAs(filepath);
                    file.BookID = book.ID;
                    file.Path = filepath;
                    service.AddFile(book, file);
                }

                return RedirectToAction("Index");
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
                var books = service.GetAllBooks();
                List<BookShortModel> list = new List<BookShortModel>();
                foreach (var book in books)
                {
                    BookShortModel bsm = book.ToBookShortModel();
                    bsm.Author = service.GetBookAuthors(book)?.FirstOrDefault()?.ToAuthorShortModel();
                    IEnumerable<ServiceLike> likes = service.GetBookLikes(book);
                    bsm.Cover = service.GetBookCovers(book)?.First().ImagePath;
                    bsm.Likes = likes.Count(e => e.Like);
                    bsm.Dislikes = likes.Count(e => e.Like);
                    list.Add(bsm);
                }
                return View(list);
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
                var book = service.GetBookById(id).ToBookShortModel();
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
                var book = service.GetBookById(id);
                service.RemoveBook(book);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }
        }

        public FileResult GetImage(int id)
        {
            var book = service.GetBookById(id);
            ServiceCover cover = service.GetBookCovers(book)?.First();
            return cover != null
                ? new FilePathResult(cover.ImagePath, "image/*")
                : new FilePathResult(Server.MapPath("~/App_Data/Uploads/Covers/" + "no_book_cover.jpg"), "image/*");
        }

    }
}