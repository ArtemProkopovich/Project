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

        public void AddComment(ServiceUser user, ServiceBook book, ServiceComment comment)
        {
            unit.Books.AddComment(book.ToDalBook(), user.ToDalUser(), comment.ToDalComment());
        }

        public void AddContent(ServiceUser user, ServiceBook book, ServiceContent content)
        {
            unit.Books.AddContent(book.ToDalBook(), user.ToDalUser(), content.ToDalContent());
        }

        public void AddLike(ServiceUser user, ServiceBook book, ServiceLike like)
        {
            unit.Books.AddLike(book.ToDalBook(), user.ToDalUser(), like.ToDalLike());
        }

        public void AddReview(ServiceUser user, ServiceBook book, ServiceReview review)
        {
            unit.Books.AddReview(book.ToDalBook(), user.ToDalUser(), review.ToDalReview());
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
