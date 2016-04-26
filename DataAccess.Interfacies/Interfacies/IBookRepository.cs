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
        void AddGenre(DalBook book, DalGenre genre);
        void DeleteGenre(DalBook book, DalGenre genre);
        void AddAuthor(DalBook book, DalAuthor author);
        void DeleteAuthor(DalBook book, DalAuthor author);
   
        void AddLike(DalBook book, DalUser user, DalLike like);
        void DeleteLike(DalBook book, DalUser user, DalLike like);
        void AddComment(DalBook book, DalUser user, DalComment comment);
        void DeleteComment(DalBook book, DalUser user, DalComment comment);
        void AddReview(DalBook book, DalUser user, DalReview review);
        void DeleteReview(DalBook book, DalUser user, DalReview reivew);
        void AddContent(DalBook book, DalUser user, DalContent content);
        void DeleteContent(DalBook book, DalUser user, DalContent content);

        IEnumerable<DalFile> GetFiles(DalBook book);
        IEnumerable<DalCover> GetCovers(DalBook book);
        IEnumerable<DalScreening> GetScreenings(DalBook book);
        void AddFile(DalBook book, DalFile file);
        void DeleteFile(DalBook book, DalFile file);
        void AddCover(DalBook book, DalCover cover);
        void DeleteCover(DalBook book, DalCover cover);
        void AddScreening(DalBook book, DalScreening screening);
        void DeleteScreening(DalBook book, DalScreening screening);
    }
}
