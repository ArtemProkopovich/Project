using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service.Interfacies;
using Service.Interfacies.Entities;
using WebApplication.Infrastructure.Mappers;
using WebApplication.Models.BookModels;
using WebApplication.Models.ContentModels;
using WebApplication.Models.UserModels;

namespace WebApplication.Models.DataModels
{
    public class Review
    {
        private static readonly IServiceManager manager = DependencyResolver.Current.GetService<IServiceManager>();

        public static ReviewModel GetReviewModel(ServiceReview review)
        {
            UserShortModel user = manager.userService.GetUserProfile(review.UserID)?.ToUserShortModel() ??
                                  new ServiceUserProfile() { ID = review.UserID }.ToUserShortModel();
            return review.ToReviewModel(user, Book.GetBookShortModel(review.BookID, review.UserID));
        }

        public static IEnumerable<ReviewModel> GetReviewModels(int bookID)
        {
            var book = manager.bookService.GetBookById(bookID);
            return manager.commentService.GetBookReviews(book).Select(GetReviewModel);
        }

        public static ServiceReview GetServiceReview(ReviewModel model)
        {
            return model.ToServiceReview();
        }
    }
}