using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Service.Interfacies.Entities;
using WebApplication.Models.BookModels;
using WebApplication.Models.ContentModels;
using WebApplication.Models.UserModels;

namespace WebApplication.Infrastructure.Mappers
{
    public static class ReviewMapper
    {
        public static ReviewModel ToReviewModel(this ServiceReview review, UserShortModel user, BookShortModel book)
        {
            return new ReviewModel()
            {
                ID = review.ID,
                Book = book,
                Header = review.Header,
                PublishTime = review.PublishTime,
                Text = review.Text,
                Type =
                    (review.Type < 0)
                        ? ReviewType.Negative
                        : review.Type == 0 ? ReviewType.Neutral : ReviewType.Positive,
                User = user,
            };
        }

        public static ServiceReview ToServiceReview(this ReviewModel review)
        {
            return new ServiceReview()
            {
                ID = review.ID,
                BookID = review.Book.ID,
                Header = review.Header,
                PublishTime = review.PublishTime,
                Text = review.Text,
                Type =
                    (ReviewType.Negative == review.Type)
                        ? -1
                        : review.Type == ReviewType.Neutral ? 0 : 1,
                UserID = review.User.ID,
            };
        }
    }
}