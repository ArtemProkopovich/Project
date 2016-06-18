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
            unit.Books.AddComment(comment.ToDalComment());
            unit.Save();
        }

        public void AddContent(ServiceContent content)
        {
            unit.Books.AddContent(content.ToDalContent());
            unit.Save();
        }

        public void AddLike(ServiceLike like)
        {
            unit.Books.AddLike(like.ToDalLike());
            unit.Save();
        }

        public void AddReview(ServiceReview review)
        {
            unit.Books.AddReview(review.ToDalReview());
            unit.Save();
        }

        public IEnumerable<ServiceComment> GetBookComments(ServiceBook book)
        {
            return unit.Books.GetComments(book.ToDalBook()).Select(e => e.ToServiceComment());
        }

        public IEnumerable<ServiceContent> GetBookContents(ServiceBook book)
        {
            return unit.Books.GetContents(book.ToDalBook()).Select(e => e.ToServiceContent());
        }

        public IEnumerable<ServiceLike> GetBookLikes(ServiceBook book)
        {
            return unit.Books.GetLikes(book.ToDalBook()).Select(e => e.ToServiceLike());
        }

        public IEnumerable<ServiceReview> GetBookReviews(ServiceBook book)
        {
            return unit.Books.GetReviews(book.ToDalBook()).Select(e => e.ToServiceReview());
        }

        public IEnumerable<ServiceComment> GetUserComments(ServiceUser user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ServiceContent> GetUserContents(ServiceUser user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ServiceReview> GetUserReviews(ServiceUser user)
        {
            throw new NotImplementedException();
        }

        public void RemoveComment(ServiceComment comment)
        {
            unit.Books.DeleteComment(comment.ToDalComment());
        }

        public void RemoveContent(ServiceContent content)
        {
            unit.Books.DeleteContent(content.ToDalContent());
        }

        public void RemoveLike(ServiceLike like)
        {
            unit.Books.DeleteLike(like.ToDalLike());
        }

        public void RemoveReview(ServiceReview review)
        {
            unit.Books.DeleteReview(review.ToDalReview());
        }
    }
}
