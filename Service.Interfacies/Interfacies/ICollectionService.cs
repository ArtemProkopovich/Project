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
        void AddUserCollection(ServiceUser user, ServiceCollection collection);
        void RemoveCollection(ServiceCollection collection);
        void AddBook(ServiceCollection collection, ServiceBook book);
        void RemoveBook(ServiceCollection collection, ServiceCollectionBook book);
        void AddBookmark(ServiceCollectionBook book, ServiceBookmark bookmark);
        void RemoveBookmark(ServiceBookmark bookmark);
        void AddQuote(ServiceCollectionBook book, ServiceQuote quote);
        void RemoveQuote(ServiceQuote quote);
        IEnumerable<ServiceCollectionBook> GetCollectionBooks(ServiceCollection collection);
        IEnumerable<ServiceCollection> GetUserCollections(ServiceUser user);
        IEnumerable<ServiceCollection> FindAll(Func<ServiceCollection, bool> func);
    }
}
