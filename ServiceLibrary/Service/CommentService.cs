using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfacies;
using Service.Interfacies;
using Service.Interfacies.Entities;
using ServiceLibrary.Mappers;

namespace ServiceLibrary.Service
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork unit;

        public CommentService(IUnitOfWork unit)
        {
            this.unit = unit;
        }

        public void AddComment(ServiceComment comment)
        {
            unit.Comments.Create(comment.ToDalComment());
            unit.Save();
        }

        public void AddContent(ServiceContent content)
        {
            unit.Contents.Create(content.ToDalContent());
            unit.Save();
        }

        public void AddLike(ServiceLike like)
        {
            unit.Likes.Create(like.ToDalLike());
            unit.Save();
        }

        public void AddReview(ServiceReview review)
        {
            unit.Reviews.Create(review.ToDalReview());
            unit.Save();
        }

        public IEnumerable<ServiceComment> GetBookComments(ServiceBook book)
        {
            return unit.Comments.FindAll(e => e.BookID == book.ID).Select(e => e.ToServiceComment());
        }

        public IEnumerable<ServiceContent> GetBookContents(ServiceBook book)
        {
            return unit.Contents.FindAll(e => e.BookID == book.ID).Select(e => e.ToServiceContent());
        }

        public IEnumerable<ServiceLike> GetBookLikes(ServiceBook book)
        {
            return unit.Likes.FindAll(e => e.BookID == book.ID).Select(e => e.ToServiceLike());
        }

        public IEnumerable<ServiceReview> GetBookReviews(ServiceBook book)
        {
            return unit.Reviews.FindAll(e => e.BookID == book.ID).Select(e => e.ToServiceReview());
        }

        public IEnumerable<ServiceComment> GetUserComments(ServiceUser user)
        {
            return unit.Comments.FindAll(e => e.UserID == user.ID).Select(e => e.ToServiceComment());
        }

        public IEnumerable<ServiceContent> GetUserContents(ServiceUser user)
        {
            return unit.Contents.FindAll(e => e.UserID == user.ID).Select(e => e.ToServiceContent());
        }

        public IEnumerable<ServiceReview> GetUserReviews(ServiceUser user)
        {
            return unit.Reviews.FindAll(e => e.UserID == user.ID).Select(e => e.ToServiceReview());
        }

        public void RemoveComment(ServiceComment comment)
        {
            unit.Comments.Delete(comment.ToDalComment());
            unit.Save();
        }

        public void RemoveContent(ServiceContent content)
        {
            unit.Contents.Delete(content.ToDalContent());
            unit.Save();
        }

        public void RemoveLike(ServiceLike like)
        {
            unit.Likes.Delete(like.ToDalLike());
            unit.Save();
        }

        public void RemoveReview(ServiceReview review)
        {
            unit.Reviews.Delete(review.ToDalReview());
            unit.Save();
        }

        public void UpdateLike(ServiceLike like)
        {
            unit.Likes.Update(like.ToDalLike());
            unit.Save();
        }
    }
}
