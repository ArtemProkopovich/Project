using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service.Interfacies;
using WebApplication.Models.BookModels;
using WebApplication.Infrastructure.Mappers;
using WebApplication.Models.AuthorModels;
using WebApplication.Models.CollectionModels;

namespace WebApplication.Models.DataModels
{
    public class Book
    {
        private static readonly IServiceManager manager = DependencyResolver.Current.GetService<IServiceManager>();

        public static BookShortModel GetBookShortModel(int bookID, int userID)
        {
            var book = manager.bookService.GetBookById(bookID);
            var model = book.ToBookShortModel();
            model.Author = manager.bookService.GetBookAuthors(book)?.FirstOrDefault()?.ToAuthorShortModel();
            model.Cover = manager.bookService.GetBookCovers(book)?.FirstOrDefault()?.ImagePath;
            model.Likes = Like.GetLikeButtonsModel(bookID, userID);
            return model;
        }

        public static BookCreateModel GetBookCreateModel()
        {
            return new BookCreateModel();
        }

        public static BookIndexPageModel GetBookIndexPageModel()
        {
            BookIndexPageModel result = new BookIndexPageModel();
            return result;
        }

        public static BookPageModel GetBookPageModel(int id, int userID)
        {
            var book = manager.bookService.GetFullBookInfo(id);
            BookPageModel result = book.ServiceBookToModelBook();
            result.Authors = book.Authors.Select(e => e.ToAuthorShortModel());
            result.Comments = book.Comments.Select(Comment.GetCommentModel);
            result.Contents = book.Contents.Select(Content.GetContentModel);
            result.Covers = book.Covers.Select(e => e.ToCoverModel());
            result.Genres = book.Genres.Select(e => e.ToGenreModel());
            result.Likes = Like.GetLikeButtonsModel(id, userID);
            result.Lists = book.Lists.Select(e => e.ToListModel());
            result.Reviews = book.Review.Select(Review.GetReviewModel);
            result.Tags = book.Tags.Select(Tag.GetTagModel);
            result.Screening = book.Screeninigs.Select(e => e.ToScreeningModel());


            if (userID > 0)
            {
                var cwb = new List<CollectionModel>();
                var cwob = new List<CollectionModel>();
                var user = manager.userService.GetUserById(userID);
                var collections = manager.collectionService.GetUserCollections(user);
                foreach (var cl in collections)
                {
                    if (manager.collectionService.GetCollectionBooks(cl).Any(e => e.BookID == id))
                        cwb.Add(Collection.GetCollectionModel(cl));
                    else
                        cwob.Add(Collection.GetCollectionModel(cl));
                }
                result.CollectionsWithBook = cwb;
                result.CollectionWithoutBook = cwob;
            }
            return result;
        }
    }
}