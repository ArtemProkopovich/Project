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
        int AddBook(ServiceBook book);
        void RemoveBook(ServiceBook book);
        ServiceBook GetBookById(int id);
        ServiceFullBook GetFullBookInfo(int id);
        ServiceFullBook GetFullBookInfo(ServiceBook book);
        Stream GetBookFile(ServiceFile file);
        void UpdateBook(ServiceBook book);
        void AddCover(ServiceBook book, ServiceCover cover);
        void RemoveCover(ServiceCover cover);
        void AddFile(ServiceBook book, ServiceFile file);
        void RemoveFile(ServiceFile file);
        void AddScreening(ServiceBook book, ServiceScreening screening);
        void RemoveScreening(ServiceScreening screening);
        ServiceBook FindFirst(Func<ServiceBook, bool> func);
        IEnumerable<ServiceBook> FindAll(Func<ServiceBook, bool> func);
        IEnumerable<ServiceBook> GetUserBooks(ServiceUser user);
        ServiceBook RandomBook();
        ServiceBook RandomBook(Func<ServiceBook, bool> func);
        IEnumerable<ServiceLike> GetBookLikes(ServiceBook book);
        IEnumerable<ServiceAuthor> GetBookAuthors(ServiceBook book);
    }
}
