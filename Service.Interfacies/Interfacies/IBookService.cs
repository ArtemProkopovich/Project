using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Interfacies.Entities;

namespace Service.Interfacies
{
    public interface IBookService
    {
        void AddBook(ServiceBook book);
        void RemoveBook(ServiceBook book);
        ServiceBook GetRandomBook();
        ServiceBook GetBookById(int id);
        ServiceBook GetBookByName(string name);
        ServiceFullBook GetFullBookInfo(int id);
        ServiceFullBook GetFullBookInfo(ServiceBook book);
        Stream GetBookFile(ServiceFile file);
        void UpdateBook(ServiceBook book);
        void AddCover(ServiceBook book, ServiceCover cover);
        void RemoveCover(ServiceCover cover);
        IEnumerable<ServiceCover> GetBookCovers(ServiceBook book);
        void AddFile(ServiceBook book, ServiceFile file);
        void RemoveFile(ServiceFile file);
        void AddScreening(ServiceBook book, ServiceScreening screening);
        void RemoveScreening(ServiceScreening screening);
        ServiceBook FindFirst(Func<ServiceBook, bool> func);
        IEnumerable<ServiceBook> FindAll(Func<ServiceBook, bool> func);
        IEnumerable<ServiceBook> GetUserBooks(ServiceUser user);
        IEnumerable<ServiceBook> GetAllBooks();
        ServiceBook RandomBook();
        ServiceBook RandomBook(Func<ServiceBook, bool> func);
        IEnumerable<ServiceLike> GetBookLikes(ServiceBook book);
        IEnumerable<ServiceAuthor> GetBookAuthors(ServiceBook book);
    }
}
