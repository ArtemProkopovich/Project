using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfacies;
using DataAccess.Interfacies.Entities;
using ORMLibrary;
using DataAccessLibrary.Mappers;

namespace DataAccessLibrary.Repository
{
    public class CollectionRepository : ICollectionRepository
    {
        private readonly ProjectDataEntities context;
        public CollectionRepository(ProjectDataEntities context)
        {
            this.context = context;
        }

        public void AddBook(DalCollection collection, DalBook book)
        {
            var dbBook = context.Books.FirstOrDefault(e => e.BookID == book.ID);
            var dbCl = context.Collections.FirstOrDefault(e => e.CollectionID == collection.ID);
            if (dbBook != null && dbCl != null)
            {
                Collection_Book cb = new Collection_Book();
                cb.IsRead = null;
                cb.BookID = dbBook.BookID;
                cb.CollectionID = dbCl.CollectionID;
                context.Collection_Book.Add(cb);
            }
        }

        public void AddBookmark(DalCollectionBook collectionBook, DalBookmark bookmark)
        {
            var dbCb = context.Collection_Book.FirstOrDefault(e => e.Collection_BookID == collectionBook.ID);
            if (dbCb != null)
            {
                dbCb.Bookmarks.Add(bookmark.ToOrmBookmark());
            }
        }

        public void AddQuote(DalCollectionBook collectionBook, DalQuote quote)
        {
            var dbCb = context.Collection_Book.FirstOrDefault(e => e.Collection_BookID == collectionBook.ID);
            if (dbCb != null)
            {
                dbCb.Quotes.Add(quote.ToOrmQuote());
            }
        }

        public void Create(DalCollection entity)
        {
            context.Collections.Add(entity.ToOrmCollection());
        }

        public void Delete(DalCollection entity)
        {
            var cl = context.Collections.FirstOrDefault(e => e.CollectionID == entity.ID);
            if (cl != null)
                context.Collections.Remove(cl);
        }

        public void DeleteBook(DalCollection collection, DalCollectionBook book)
        {
            var dbBook = context.Collection_Book.FirstOrDefault(e => e.Collection_BookID == book.ID);
            var dbCl = context.Collections.FirstOrDefault(e => e.CollectionID == collection.ID);
            if (dbBook != null && dbCl != null)
            {
                dbCl.Collection_Book.Remove(dbBook);
            }
        }

        public void DeleteBookmark(DalCollectionBook collectionBook, DalBookmark bookmark)
        {
            var dbBook = context.Collection_Book.FirstOrDefault(e => e.Collection_BookID == collectionBook.ID);
            var dbBm = context.Bookmarks.FirstOrDefault(e => e.BookmarkID == bookmark.ID);
            if (dbBook != null && dbBm != null)
            {
                context.Bookmarks.Remove(dbBm);
            }
        }

        public void DeleteQuote(DalCollectionBook collectionBook, DalQuote quote)
        {
            var dbBook = context.Collection_Book.FirstOrDefault(e => e.Collection_BookID == collectionBook.ID);
            var dbQ = context.Quotes.FirstOrDefault(e => e.QuoteID == quote.ID);
            if (dbBook != null && dbQ != null)
            {
                context.Quotes.Remove(dbQ);
            }
        }

        public DalCollection Find(Expression<Func<DalCollection, bool>> f)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalCollection> FindAll(Expression<Func<DalCollection, bool>> f)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalCollection> GetAll()
        {
            return context.Collections.Select(e => e.ToDalCollection());
        }

        public DalCollection GetById(int key)
        {
            return context.Collections.FirstOrDefault(e => e.CollectionID == key)?.ToDalCollection();
        }

        public IEnumerable<DalBook> GetCollcetionBooks(DalCollection collection)
        {
            return context.Collections.FirstOrDefault(e => e.CollectionID == collection.ID)?
                .Collection_Book.Select(e => e.Books.ToDalBook());
        }

        public IEnumerable<DalCollectionBook> GetCollectionBooks(DalCollection collection)
        {
            return context.Collections.FirstOrDefault(e => e.CollectionID == collection.ID)?
                    .Collection_Book.Select(e => e.ToDalCollectionBook());
        }

        public IEnumerable<DalCollection> GetUserCollections(DalUser user)
        {
            return context.Collections.Where(e => e.UserID == user.ID).Select(e => e.ToDalCollection());
        }

        public void Update(DalCollection entity)
        {
            var a = context.Collections.FirstOrDefault(e => e.CollectionID == entity.ID);
            if (a != null)
            {
                a.Description = entity.Description;
                a.Name = entity.Name;
            }
        }
    }
}
