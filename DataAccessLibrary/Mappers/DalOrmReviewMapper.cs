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
                ID = review.ReviewID,
                BookID = review.BookID,
                UserID = review.UserID,
                Text = review.Text
            };
        }
    }
}
