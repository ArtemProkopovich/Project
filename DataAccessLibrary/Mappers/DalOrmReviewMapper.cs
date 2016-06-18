using DataAccess.Interfacies.Entities;
using ORMLibrary;

namespace DataAccessLibrary.Mappers
{
    public static class DalOrmReviewMapper
    {
        public static Reviews ToOrmReview(this DalReview review)
        {
            return new Reviews
            {
                Review_Type = review.Type,
                Header = review.Header,
                Added_Date = review.PublishTime,
                ReviewID = review.ID,
                BookID = review.BookID,
                UserID = review.UserID,
                Text = review.Text
            };
        }

        public static DalReview ToDalReview(this Reviews review)
        {
            return new DalReview
            {
                Type = review.Review_Type,
                Header = review.Header,
                PublishTime = review.Added_Date,
                ID = review.ReviewID,
                BookID = review.BookID,
                UserID = review.UserID,
                Text = review.Text
            };
        }
    }
}
