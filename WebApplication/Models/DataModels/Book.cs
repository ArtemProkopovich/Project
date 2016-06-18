using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service.Interfacies;
using WebApplication.Models.BookModels;
using WebApplication.Infrastructure.Mappers;
using WebApplication.Models.AuthorModels;

namespace WebApplication.Models.DataModels
{
    public class Book
    {
        private static readonly IServiceManager manager = DependencyResolver.Current.GetService<IServiceManager>();

        public static BookCreateModel GetBookCreateModel()
        {
            return new BookCreateModel();
        }

        public static BookIndexPageModel GetBookIndexPageModel()
        {
            BookIndexPageModel result = new BookIndexPageModel();
            return result;
        }

        public static BookPageModel GetBookPageModel(int id)
        {
            var book = manager.bookService.GetFullBookInfo(id);
            BookPageModel result = book.ServiceBookToModelBook();
            result.Authors = book.Authors.Select(e => e.ToAuthorShortModel());
            result.Comments = book.Comments.Select(Comment.GetCommentModel);
            result.Contents = book.Contents.Select(Content.GetContentModel);
            result.Covers = book.Covers.Select(e => e.ToCoverModel());
            result.Genres = book.Genres.Select(e => e.ToGenreModel());
            result.Like = book.Likes?.Count(e => e.Like) ?? 0;
            result.Dislike = book.Likes?.Count(e => !e.Like) ?? 0;
            result.LikeCount = book.Likes?.Count() ?? 0;
            result.Lists = book.Lists.Select(e => e.ToListModel());
            result.Reviews = book.Review.Select(Review.GetReviewModel);
            result.Tags = book.Tags.Select(e => e.ToTagModel());
            result.Screening = book.Screeninigs.Select(e => e.ToScreeningModel());
            return result;
        }
    }
}