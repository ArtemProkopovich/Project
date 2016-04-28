using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfacies.Entities;

namespace DataAccess.Interfacies
{
    public interface ICollectionRepository : IRepository<DalCollection>
    {
        IEnumerable<DalCollection> GetUserCollections(DalUser user);
        IEnumerable<DalCollectionBook> GetCollectionBooks(DalCollection collection);
        IEnumerable<DalBook> GetCollcetionBooks(DalCollection collection);
        void AddUserCollection(DalUser user, DalCollection collection);
        void AddBook(DalCollection collection, DalBook book);
        void DeleteBook(DalCollection collection, DalCollectionBook book);
        void AddBookmark(DalCollectionBook collectionBook, DalBookmark bookmark);
        void DeleteBookmark(DalBookmark bookmark);
        void AddQuote(DalCollectionBook collectionBook, DalQuote quote);
        void DeleteQuote(DalQuote quote);
    }
}
