using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfacies.Entities;

namespace DataAccess.Interfacies
{
    public interface IBookRepository : IRepository<DalBook>
    {
        void AddTag(DalBook book, DalTag tag);
        void DeleteTag(DalBook book, DalTag tag);
        IEnumerable<DalTag> GetTags(DalBook book);
        void AddGenre(DalBook book, DalGenre genre);
        void DeleteGenre(DalBook book, DalGenre genre);
        IEnumerable<DalGenre> GetGenres(DalBook book);
        void AddAuthor(DalBook book, DalAuthor author);
        void DeleteAuthor(DalBook book, DalAuthor author);
        IEnumerable<DalAuthor> GetAuthors(DalBook book);

        void AddLike(DalBook book, DalUser user, DalLike like);
        void DeleteLike(DalLike like);
        IEnumerable<DalLike> GetLikes(DalBook book);
        void AddComment(DalBook book, DalUser user, DalComment comment);
        void DeleteComment(DalComment comment);
        IEnumerable<DalComment> GetComments(DalBook book);
        void AddReview(DalBook book, DalUser user, DalReview review);
        void DeleteReview(DalReview reivew);
        IEnumerable<DalReview> GetReviews(DalBook book);
        void AddContent(DalBook book, DalUser user, DalContent content);
        void DeleteContent(DalContent content);
        IEnumerable<DalContent> GetContents(DalBook book);

        IEnumerable<DalFile> GetFiles(DalBook book);
        IEnumerable<DalCover> GetCovers(DalBook book);
        IEnumerable<DalScreening> GetScreenings(DalBook book);
        void AddFile(DalBook book, DalFile file);
        void DeleteFile(DalFile file);
        void AddCover(DalBook book, DalCover cover);
        void DeleteCover(DalCover cover);
        void AddScreening(DalBook book, DalScreening screening);
        void DeleteScreening(DalScreening screening);
    }
}
