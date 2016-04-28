using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Interfacies.Entities;

namespace Service.Interfacies
{
    public interface ICommentService
    {
        void AddLike(ServiceUser user , ServiceBook book, ServiceLike like);
        void RemoveLike(ServiceLike like);
        IEnumerable<ServiceLike> GetBookLikes(ServiceBook book);
        void AddComment(ServiceUser user, ServiceBook book, ServiceComment comment);
        void RemoveComment(ServiceComment comment);
        IEnumerable<ServiceComment> GetBookComments(ServiceBook book);
        void AddReview(ServiceUser user, ServiceBook book, ServiceReview review);
        void RemoveReview(ServiceReview review);
        IEnumerable<ServiceReview> GetBookReviews(ServiceBook book);
        void AddContent(ServiceUser user, ServiceBook book, ServiceContent content);
        void RemoveContent(ServiceContent content);
        IEnumerable<ServiceContent> GetBookContents(ServiceBook book);
    }
}
