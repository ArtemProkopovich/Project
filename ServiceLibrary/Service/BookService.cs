using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfacies;
using DataAccess.Interfacies.Entities;
using Service.Interfacies;
using Service.Interfacies.Entities;
using ServiceLibrary.Mappers;

namespace ServiceLibrary.Service
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork unit;

        public BookService(IUnitOfWork unit)
        {
            this.unit = unit;
        }
        public void AddBook(ServiceBook book)
        {
            unit.Books.Create(book.ToDalBook());
            unit.Save();
        }

        public void AddCover(ServiceBook book, ServiceCover cover)
        {
            unit.Books.AddCover(book.ToDalBook(), cover.ToDalCover());
            unit.Save();
        }

        public void AddFile(ServiceBook book, ServiceFile file)
        {
            unit.Books.AddFile(book.ToDalBook(), file.ToDalFile());
            unit.Save();
        }

        public void AddScreening(ServiceBook book, ServiceScreening screening)
        {
            unit.Books.AddScreening(book.ToDalBook(), screening.ToDalScreening());
            unit.Save();
        }

        public IEnumerable<ServiceBook> FindAll(Func<ServiceBook, bool> func)
        {
            throw new NotImplementedException();
        }

        public ServiceBook FindFirst(Func<ServiceBook, bool> func)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ServiceAuthor> GetBookAuthors(ServiceBook book)
        {
            return unit.Books.GetAuthors(book.ToDalBook()).Select(e=>e.ToServiceAuthor());
        }

        public ServiceBook GetBookById(int id)
        {
            return unit.Books.GetById(id)?.ToServiceBook();
        }

        public ServiceBook GetBookByName(string name)
        {
            return unit.Books.GetByName(name)?.ToServiceBook();
        }

        public IEnumerable<ServiceCover> GetBookCovers(ServiceBook book)
        {
            return unit.Books.GetCovers(book.ToDalBook())?.Select(e => e.ToServiceCover());
        }

        public Stream GetBookFile(ServiceFile file)
        {
            DalBook book = unit.Books.GetById(file.BookID);
            return new FileStream(unit.Books.GetFiles(book).Single(e => e.ID == file.ID).Path, FileMode.Open,
                FileAccess.Read);
        }

        public IEnumerable<ServiceLike> GetBookLikes(ServiceBook book)
        {
            return unit.Books.GetLikes(book.ToDalBook()).Select(e => e.ToServiceLike());
        }

        public ServiceFullBook GetFullBookInfo(ServiceBook book)
        {
            var dalBook = book.ToDalBook();
            ServiceFullBook fBook = new ServiceFullBook
            {
                BookData = book,
                Authors = unit.Books.GetAuthors(dalBook).Select(e => e.ToServiceAuthor()),
                Comments = unit.Books.GetComments(dalBook).Select(e => e.ToServiceComment()),
                Contents = unit.Books.GetContents(dalBook).Select(e=>e.ToServiceContent()),
                Likes = unit.Books.GetLikes(dalBook).Select(e=>e.ToServiceLike()),
                Lists = unit.Books.GetLists(dalBook).Select(e=>e.ToServiceList()),
                Review = unit.Books.GetReviews(dalBook).Select(e=>e.ToServiceReview()),
                Covers = unit.Books.GetCovers(dalBook).Select(e => e.ToServiceCover()),
                Files = unit.Books.GetFiles(dalBook).Select(e => e.ToServiceFile()),
                Genres = unit.Books.GetGenres(dalBook).Select(e => e.ToServiceGenre()),
                Screeninigs = unit.Books.GetScreenings(dalBook).Select(e => e.ToServiceScreening()),
                Tags = unit.Books.GetTags(dalBook).Select(e => e.ToServiceTag())
            };
            return fBook;
        }

        public ServiceFullBook GetFullBookInfo(int id)
        {
            ServiceBook book = unit.Books.GetById(id).ToServiceBook();
            return GetFullBookInfo(book);
        }

        public ServiceBook GetRandomBook()
        {
            return unit.Books.GetRandomBook()?.ToServiceBook();
        }

        public IEnumerable<ServiceBook> GetAllBooks()
        {
            return unit.Books.GetAll().Select(e => e.ToServiceBook());
        }
        public IEnumerable<ServiceBook> GetUserBooks(ServiceUser user)
        {
            return
                unit.Collections.GetUserCollections(user.ToDalUser())
                    .SelectMany(cl => unit.Collections.GetCollcetionBooks(cl).Select(e => e.ToServiceBook()));
        }

        public ServiceBook RandomBook()
        {
            Random random = new Random();
            DalBook book = null;
            while (book == null)
                book = unit.Books.GetById(random.Next());
            return book.ToServiceBook();
        }

        public ServiceBook RandomBook(Func<ServiceBook, bool> func)
        {
            throw new NotImplementedException();
        }

        public void RemoveBook(ServiceBook book)
        {
            unit.Books.Delete(book.ToDalBook());
            unit.Save();
        }

        public void RemoveCover(ServiceCover cover)
        {
            unit.Books.DeleteCover(cover.ToDalCover());
            unit.Save();
        }

        public void RemoveFile(ServiceFile file)
        {
            unit.Books.DeleteFile(file.ToDalFile());
            unit.Save();
        }

        public void RemoveScreening(ServiceScreening screening)
        {
            unit.Books.DeleteScreening(screening.ToDalScreening());
            unit.Save();
        }

        public void UpdateBook(ServiceBook book)
        {
            unit.Books.Update(book.ToDalBook());
            unit.Save();
        }
    }
}
