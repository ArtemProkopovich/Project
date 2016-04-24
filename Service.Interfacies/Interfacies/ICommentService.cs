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
        void AddComment(ServiceComment comment);
        void RemoveComment(ServiceComment comment);
        void AddReview(ServiceReview review);
        void RemoveReview(ServiceReview review);
        void AddContent(ServiceContent content);
        void RemoveContent(ServiceContent content);
    }
}
