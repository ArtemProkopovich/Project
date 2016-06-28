using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service.Interfacies;
using Service.Interfacies.Entities;
using WebApplication.Infrastructure;
using WebApplication.Models.BookModels;
using WebApplication.Infrastructure.Mappers;
using WebApplication.Models.AuthorModels;
using WebApplication.Models.CollectionModels;
using WebApplication.Models.ViewModels.BookModels;
using WebApplication.Models.ViewModels.ContentModels;
using WebApplication.Models.ViewModels.ListModels;

namespace WebApplication.Models.DataModels
{
    public class Book
    {
        private static readonly IServiceManager manager = DependencyResolver.Current.GetService<IServiceManager>();

        public static BookShortModel GetBookShortModel(int bookID, int userID)
        {
            var book = manager.bookService.GetBookById(bookID);
            return GetBookShortModel(book, userID);
        }

        public static BookShortModel GetBookShortModel(ServiceBook book, int userID)
        {
            var model = book.ToBookShortModel();
            model.Author = manager.bookService.GetBookAuthors(book)?.FirstOrDefault()?.ToAuthorShortModel();
            model.Cover = manager.bookService.GetBookCovers(book)?.FirstOrDefault()?.ImagePath;
            model.Likes = Like.GetLikeButtonsModel(book.ID, userID);
            return model;
        }

        public static BookIndexPageModel GetBookIndexPageModel()
        {
            BookIndexPageModel result = new BookIndexPageModel();
            var random = RandomInit.GetRandom();
            int booksCount = manager.bookService.GetAllBooksCount();
            List<BookModel> books = new List<BookModel>();
            for (int i = 0; i < 4; i++)
            {
                books.Add(
                    manager.bookService.OrderTake(ServiceOrderType.Likes, random.Next(booksCount), 1)
                        .FirstOrDefault()
                        .ToBookModel());
            }
            List<AuthorShortModel> authors = new List<AuthorShortModel>();
            int authorsCount = manager.authorService.GetAuthorsCount();
            for (int i = 0; i < 4; i++)
            {
                authors.Add(
                    manager.authorService.OrderTake(random.Next(authorsCount), 1).FirstOrDefault().ToAuthorShortModel());
            }
            List<GenreFirstModel> genres = new List<GenreFirstModel>();
            var dbGenres = manager.listService.GetAllGenres().ToList();
            for (int i = 0; i < 4 && dbGenres.Count>0; i++)
            {
                genres.Add(Genre.GetGenreFirstModel(dbGenres.ElementAt(random.Next(dbGenres.Count-1))));
            }
            List<ListShortModel> lists = new List<ListShortModel>();
            var dbLists = manager.listService.GetAllLists().ToList();
            for (int i = 0; i < 4 && dbLists.Count>0; i++)
            {
                lists.Add(List.GetListShortModel(dbLists.ElementAt(random.Next(dbLists.Count-1))));
            }
            result.Authors = authors;
            result.Books = books;
            result.Genres = genres;
            result.Lists = lists;
            return result;
        }

        public static BookListModel GetBookListModel(SortBy filter, int booksOnPage, int currentPage, int userID)
        {
            BookListModel model = new BookListModel();
            model.bookOnPageCount = booksOnPage;
            model.currentPage = currentPage;
            model.Filter = filter;
            int allBooksCount = manager.bookService.GetAllBooksCount();
            int maxPage = allBooksCount%booksOnPage == 0 ? allBooksCount/booksOnPage : allBooksCount/booksOnPage + 1;
            maxPage = maxPage == 0 ? 1 : maxPage;
            currentPage = currentPage < maxPage ? currentPage < 1 ? 1 : currentPage : maxPage;
            model.bookOnPageCount = booksOnPage;
            model.currentPage = currentPage;
            model.pageCount = maxPage;
            model.Books =
                manager.bookService.OrderTake(ToSrvOrder(filter), (currentPage - 1)*booksOnPage, booksOnPage)
                    .Select(e => GetBookShortModel(e, userID));
            return model;
        }

        private static ServiceOrderType ToSrvOrder(SortBy filter)
        {
            switch (filter)
            {
                case SortBy.Comments:
                    return ServiceOrderType.Comments;
                case SortBy.Read:
                    return ServiceOrderType.Reads;
                default:
                    return ServiceOrderType.Likes;
            }
        }

        public static BookPageModel GetBookPageModel(int id, int userID)
        {
            var book = manager.bookService.GetFullBookInfo(id);
            BookPageModel result = book.ServiceBookToModelBook();
            result.Authors = book.Authors.Select(e => e.ToAuthorShortModel());
            result.Comments = book.Comments.Select(Comment.GetCommentModel);
            result.Contents = book.Contents.Select(Content.GetContentModel);
            result.Covers = book.Covers.Select(e => e.ToCoverModel());
            if (!result.Covers.Any())
            {
                result.Covers = new List<CoverModel>() {new CoverModel() {ID = 0, BookID = id}};
            }                
            result.Genres = book.Genres.Select(e => e.ToGenreModel());
            result.Likes = Like.GetLikeButtonsModel(id, userID);
            result.Lists = book.Lists.Select(e => e.ToListModel());
            result.Reviews = book.Review.Select(Review.GetReviewModel);
            result.Tags = book.Tags.Select(Tag.GetTagModel);
            result.Screening = book.Screeninigs.Select(e => e.ToScreeningModel());
            result.Collections = CollectionBook.GetBookInCollectionModel(id, userID);
            return result;
        }

        public static BookCreateModel GetBookCreateModel()
        {
            return new BookCreateModel()
            {
                AuthorList = manager.authorService.GetAllAuthors(),
                GenreList = manager.listService.GetAllGenres(),
                TagList = manager.listService.GetAllTags()
            };
        }

        public static BookEditModel GetBookEditModel(int id)
        {
            var book = manager.bookService.GetFullBookInfo(id);
            var result = book.BookData.ToEditModel();
            result.AuthorList = manager.authorService.GetAllAuthors();
            result.GenreList = manager.listService.GetAllGenres();
            result.TagList = manager.listService.GetAllTags();
            result.Authors = book.Genres.Select(e=>e.ID).ToArray();
            result.Genres = book.Genres.Select(e => e.ID).ToArray();
            result.Tags = book.Tags.Select(e => e.ID).ToArray();
            return result;
        }

        public static BookFileEditModel GetBookFileEditModel(int id)
        {
            BookFileEditModel result = new BookFileEditModel();
            var book = manager.bookService.GetFullBookInfo(id);
            result.Book = book.BookData.ToBookModel();
            result.UpFiles = book.Files;
            result.UpCovers = book.Covers;
            return result;
        }

        public static int SaveBook(BookCreateModel model, int userID, HttpServerUtilityBase server)
        {
            int id = manager.bookService.AddBook(model.CreateModelToServiceBook());
            var book = manager.bookService.GetBookById(id);
            var authors = manager.authorService.GetAllAuthors().ToList();
            //Adding authors
            foreach (var author in model.Authors?.Select(authorID => authors.FirstOrDefault(e => e.ID == authorID)).Where(e => e != null) ?? new List<ServiceAuthor>())
            {
                manager.authorService.AddAuthorBook(author, book);
            }

            var genres = manager.listService.GetAllGenres().ToList();
            //Adding genres
            foreach (var genre in model.Genres?.Select(genreID => genres.FirstOrDefault(e => e.ID == genreID)).Where(genre => genre != null)?? new List<ServiceGenre>())
            {
                manager.listService.AddBookGenre(book, genre);
            }

            var tags = manager.listService.GetAllTags().ToList();
            //Adding tags
            foreach (var tag in model.Tags?.Select(tagID => tags.FirstOrDefault(e => e.ID == tagID)).Where(tag => tag != null)?? new List<ServiceTag>())
            {
                manager.listService.AddBookTag(book, tag);
            }
            //Adding files
            if (model.Files != null)
            {
                foreach (var file in model.Files)
                {
                    if (file != null)
                    {
                        string filepath = File.SaveFile(server, file, "~/App_Data/Uploads/Files/");
                        manager.bookService.AddFile(book,
                            new ServiceFile {BookID=id, Path = filepath, Format = Path.GetExtension(filepath)});
                    }
                }
            }

            if (model.Covers != null)
            {
                //Adding covers
                foreach (var cover  in model.Covers)
                {
                    if (cover != null)
                    {
                        string filepath = File.SaveFile(server, cover, "~/App_Data/Uploads/Covers/Books");
                        manager.bookService.AddCover(book,
                            new ServiceCover {BookID = id, ImagePath = filepath});
                    }
                }
            }

            //Adding content
            if (model.Content != null)
                manager.commentService.AddContent(new ServiceContent()
                {
                    BookID = book.ID,
                    Text = model.Content,
                    UserID = userID
                });

            return id;
        }

        public static void UpdateBook(BookEditModel model)
        {
            manager.bookService.UpdateBook(model.ToServiceBook());
            var fbook = manager.bookService.GetFullBookInfo(model.ID);
            var book = fbook.BookData;
            var authors = manager.authorService.GetAllAuthors().ToList();
            //Adding authors
            foreach (var author in model.Authors?.Select(authorID => authors.FirstOrDefault(e => e.ID == authorID)).Where(e => e != null) ?? new List<ServiceAuthor>())
            {
                manager.authorService.AddAuthorBook(author, book);
            }
            model.Authors = model.Authors ?? new int[0];
            fbook.Authors = fbook.Authors.ToList();
            foreach (var author in fbook.Authors.Where(author => model.Authors.All(e => e != author.ID)))
            {
                manager.authorService.RemoveAuthorBook(author, book);
            }

            var genres = manager.listService.GetAllGenres().ToList();
            //Adding genres
            foreach (var genre in model.Genres?.Select(genreID => genres.FirstOrDefault(e => e.ID == genreID)).Where(genre => genre != null) ?? new List<ServiceGenre>())
            {
                manager.listService.AddBookGenre(book, genre);
            }

            model.Genres = model.Genres ?? new int[0];
            fbook.Genres = fbook.Genres.ToList();
            foreach (var genre in fbook.Genres.Where(genre => model.Genres.All(e => e != genre.ID)))
            {
                manager.listService.RemoveBookGenre(book, genre);
            }

            var tags = manager.listService.GetAllTags().ToList();
            //Adding tags
            foreach (var tag in model.Tags?.Select(tagID => tags.FirstOrDefault(e => e.ID == tagID)).Where(tag => tag != null) ?? new List<ServiceTag>())
            {
                manager.listService.AddBookTag(book, tag);
            }
            model.Tags = model.Tags ?? new int[0];
            fbook.Tags = fbook.Tags.ToList();
            foreach (var tag in fbook.Tags.Where(tag => model.Tags.All(e => e != tag.ID)))
            {
                manager.listService.RemoveBookTag(book, tag);
            }
        }

    }
}