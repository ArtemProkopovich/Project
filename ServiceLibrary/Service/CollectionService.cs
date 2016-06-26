using System;
using System.Collections.Generic;
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
            unit.Save();
        }

        public void AddBookmark(ServiceBookmark bookmark)
        {
            unit.Collections.AddBookmark(bookmark.ToDalBookmark());
            unit.Save();
        }

        public void AddQuote(ServiceQuote quote)
        {
            unit.Collections.AddQuote(quote.ToDalQuote());
            unit.Save();
        }

        public void AddUserCollection(ServiceCollection collection)
        {
            unit.Collections.AddUserCollection(collection.ToDalCollection());
            unit.Save();
        }

        public void ClearCollection(ServiceCollection collection)
        {
            var books = unit.Collections.GetCollectionBooks(collection.ToDalCollection());
            foreach (var book in books)
            {
                unit.Collections.DeleteBook(book);
            }
            unit.Save();
        }

        public IEnumerable<ServiceCollection> FindAll(Func<ServiceCollection, bool> func)
        {
            throw new NotImplementedException();
        }

        public ServiceBookmark GetBookmark(int id)
        {
            return unit.Collections.GetBookmark(id)?.ToServiceBookmark();
        }

        public IEnumerable<ServiceBookmark> GetBookmarks(ServiceCollectionBook cb)
        {
            return unit.Collections.GetBookmarks(cb.ToDalCollectionBook()).Select(e => e.ToServiceBookmark());
        }

        public ServiceCollectionBook GetCollectionBookById(int id)
        {
            return unit.Collections.GetCollectionBook(id)?.ToServiceCollectionBook();
        }

        public IEnumerable<ServiceCollectionBook> GetCollectionBooks(ServiceCollection collection)
        {
            return unit.Collections.GetCollectionBooks(collection.ToDalCollection()).Select(e => e.ToServiceCollectionBook());
        }

        public ServiceCollection GetCollectionById(int id)
        {
            return unit.Collections.GetById(id)?.ToServiceCollection();
        }

        public ServiceQuote GetQuote(int id)
        {
            return unit.Collections.GetQuote(id)?.ToServiceQuote();
        }

        public IEnumerable<ServiceQuote> GetQuotes(ServiceCollectionBook cb)
        {
            return unit.Collections.GetQuotes(cb.ToDalCollectionBook()).Select(e => e.ToServiceQuote());
        }

        public IEnumerable<ServiceCollection> GetUserCollections(ServiceUser user)
        {
            var collections = unit.Collections.GetUserCollections(user.ToDalUser()).Select(e => e.ToServiceCollection());
            if (!collections.Any())
            {
                DalCollection cl = new DalCollection()
                {
                    Name = "Favorite",
                    Description = "There is all you favorite books.",
                    UserID = user.ID
                };
                unit.Collections.AddUserCollection(cl);
                unit.Save();
            }
            return unit.Collections.GetUserCollections(user.ToDalUser()).Select(e => e.ToServiceCollection());
        }

        public void MoveBook(ServiceCollectionBook book, ServiceCollection collection)
        {
            unit.Collections.MoveBook(book.ToDalCollectionBook(), collection.ToDalCollection());
            unit.Save();
        }

        public void RemoveBook(ServiceCollectionBook book)
        {
            unit.Collections.DeleteBook(book.ToDalCollectionBook());
            unit.Save();
        }

        public void RemoveBookmark(ServiceBookmark bookmark)
        {
            unit.Collections.DeleteBookmark(bookmark.ToDalBookmark());
            unit.Save();
        }

        public void RemoveCollection(ServiceCollection collection)
        {
            if (collection.Name != "Favorite")
            {
                unit.Collections.Delete(collection.ToDalCollection());
                unit.Save();
            }
        }

        public void RemoveQuote(ServiceQuote quote)
        {
            unit.Collections.DeleteQuote(quote.ToDalQuote());
            unit.Save();
        }

        public void UpdateCollection(ServiceCollection collection)
        {
            unit.Collections.Update(collection.ToDalCollection());
            unit.Save();
        }
    }
}
