using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Interfacies.Entities;

namespace Service.Interfacies
{
    public interface ICollectionService
    {
        void AddUserCollection(ServiceCollection collection);
        void RemoveCollection(ServiceCollection collection);
        void UpdateCollection(ServiceCollection collection);
        void ClearCollection(ServiceCollection collection);
        void AddBook(ServiceCollection collection, ServiceBook book);
        void RemoveBook(ServiceCollectionBook book);
        void MoveBook(ServiceCollectionBook book, ServiceCollection collection);
        void AddBookmark(ServiceCollectionBook book, ServiceBookmark bookmark);
        void RemoveBookmark(ServiceBookmark bookmark);
        void AddQuote(ServiceCollectionBook book, ServiceQuote quote);
        void RemoveQuote(ServiceQuote quote);
        IEnumerable<ServiceCollectionBook> GetCollectionBooks(ServiceCollection collection);
        ServiceCollection GetCollectionById(int id);
        ServiceCollectionBook GetCollectionBookById(int id);
        IEnumerable<ServiceCollection> GetUserCollections(ServiceUser user);
        IEnumerable<ServiceCollection> FindAll(Func<ServiceCollection, bool> func);
    }
}
