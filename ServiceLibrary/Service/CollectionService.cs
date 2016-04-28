using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfacies;
using Service.Interfacies;
using Service.Interfacies.Entities;
using ServiceLibrary.Mappers;

namespace ServiceLibrary.Service
{
    public class CollectionService : ICollectionService
    {
        private readonly IUnitOfWork unit;
        public CollectionService(IUnitOfWork unit)
        {
            this.unit = unit;
        }
        public void AddBook(ServiceCollection collection, ServiceBook book)
        {
            unit.Collections.AddBook(collection.ToDalCollection(), book.ToDalBook());
        }

        public void AddBookmark(ServiceCollectionBook book, ServiceBookmark bookmark)
        {
            unit.Collections.AddBookmark(book.ToDalCollectionBook(), bookmark.ToDalBookmark());
        }

        public void AddQuote(ServiceCollectionBook book, ServiceQuote quote)
        {
            unit.Collections.AddQuote(book.ToDalCollectionBook(), quote.ToDalQuote());
        }

        public void AddUserCollection(ServiceUser user, ServiceCollection collection)
        {
            unit.Collections.AddUserCollection(user.ToDalUser(), collection.ToDalCollection());
        }

        public IEnumerable<ServiceCollection> FindAll(Func<ServiceCollection, bool> func)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ServiceCollectionBook> GetCollectionBooks(ServiceCollection collection)
        {
            return unit.Collections.GetCollectionBooks(collection.ToDalCollection()).Select(e => e.ToServiceCollectionBook());
        }

        public IEnumerable<ServiceCollection> GetUserCollections(ServiceUser user)
        {
            return unit.Collections.GetUserCollections(user.ToDalUser()).Select(e=>e.ToServiceCollection());
        }

        public void RemoveBook(ServiceCollection collection, ServiceCollectionBook book)
        {
            unit.Collections.DeleteBook(collection.ToDalCollection(), book.ToDalCollectionBook());
        }

        public void RemoveBookmark(ServiceBookmark bookmark)
        {
            unit.Collections.DeleteBookmark(bookmark.ToDalBookmark());
        }

        public void RemoveCollection(ServiceCollection collection)
        {
            unit.Collections.Delete(collection.ToDalCollection());
        }

        public void RemoveQuote(ServiceQuote quote)
        {
            unit.Collections.DeleteQuote(quote.ToDalQuote());
        }
    }
}
