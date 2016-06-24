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
        void AddLike(ServiceLike like);
        void RemoveLike(ServiceLike like);
        void UpdateLike(ServiceLike like);
        IEnumerable<ServiceLike> GetBookLikes(ServiceBook book);
        void AddComment(ServiceComment comment);
        void RemoveComment(ServiceComment comment);
        IEnumerable<ServiceComment> GetBookComments(ServiceBook book);
        IEnumerable<ServiceComment> GetUserComments(ServiceUser user);
        void AddReview(ServiceReview review);
        void RemoveReview(ServiceReview review);
        IEnumerable<ServiceReview> GetBookReviews(ServiceBook book);
        IEnumerable<ServiceReview> GetUserReviews(ServiceUser user);
        void AddContent(ServiceContent content);
        void RemoveContent(ServiceContent content);
        IEnumerable<ServiceContent> GetBookContents(ServiceBook book);
        IEnumerable<ServiceContent> GetUserContents(ServiceUser user);
    }
}
