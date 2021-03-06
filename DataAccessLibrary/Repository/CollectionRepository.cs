﻿using System;
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
        private readonly DatabaseContext context;
        public CollectionRepository(DatabaseContext context)
        {
            this.context = context;
        }

        public void AddBook(DalCollection collection, DalBook book)
        {
            var dbBook = context.Books.FirstOrDefault(e => e.BookID == book.ID);
            var dbCl = context.Collections.FirstOrDefault(e => e.CollectionID == collection.ID);
            if (dbBook != null && dbCl != null)
            {
                Collection_Book cb = new Collection_Book
                {
                    IsRead = null,
                    BookID = dbBook.BookID,
                    CollectionID = dbCl.CollectionID
                };
                context.Collection_Book.Add(cb);
            }
        }

        public void AddBookmark(DalBookmark bookmark)
        {
            var dbCb = context.Collection_Book.FirstOrDefault(e => e.Collection_BookID == bookmark.CollectionBookID);
            if (dbCb != null)
            {
                context.Bookmarks.Add(bookmark.ToOrmBookmark());
            }
        }

        public void AddQuote(DalQuote quote)
        {
            var dbCb = context.Collection_Book.FirstOrDefault(e => e.Collection_BookID == quote.CollectionBookID);
            if (dbCb != null)
            {
                context.Quotes.Add(quote.ToOrmQuote());
            }
        }

        public void AddUserCollection(DalCollection collection)
        {
            context.Collections.Add(collection.ToOrmCollection());
        }

        public int Create(DalCollection entity)
        {
            var obj = entity.ToOrmCollection();
            context.Collections.Add(obj);
            context.SaveChanges();
            return obj.CollectionID;
        }

        public void Delete(DalCollection entity)
        {
            var cl = context.Collections.FirstOrDefault(e => e.CollectionID == entity.ID);
            if (cl != null)
                context.Collections.Remove(cl);
        }

        public void DeleteBook( DalCollectionBook book)
        {
            var dbBook = context.Collection_Book.FirstOrDefault(e => e.Collection_BookID == book.ID);
            if (dbBook != null)
            {
                context.Collection_Book.Remove(dbBook);
            }
        }

        public void DeleteBookmark(DalBookmark bookmark)
        {
            //var dbBook = context.Collection_Book.FirstOrDefault(e => e.Collection_BookID == collectionBook.ID);
            var dbBm = context.Bookmarks.FirstOrDefault(e => e.BookmarkID == bookmark.ID);
            if (dbBm != null)
            {
                context.Bookmarks.Remove(dbBm);
            }
        }

        public void DeleteQuote(DalQuote quote)
        {
            //var dbBook = context.Collection_Book.FirstOrDefault(e => e.Collection_BookID == collectionBook.ID);
            var dbQ = context.Quotes.FirstOrDefault(e => e.QuoteID == quote.ID);
            if (dbQ != null)
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
            return context.Collections.ToList().Select(e => e.ToDalCollection());
        }

        public DalBookmark GetBookmark(int id)
        {
            return context.Bookmarks.FirstOrDefault(e => e.BookmarkID == id)?.ToDalBookmark();
        }

        public IEnumerable<DalBookmark> GetBookmarks(DalCollectionBook cb)
        {
            return context.Bookmarks.Where(e => e.Collection_BookID == cb.ID).ToList().Select(e => e.ToDalBookmark());
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

        public DalCollectionBook GetCollectionBook(int id)
        {
            return context.Collection_Book.FirstOrDefault(e => e.Collection_BookID == id)?.ToDalCollectionBook();
        }

        public IEnumerable<DalCollectionBook> GetCollectionBooks(DalCollection collection)
        {
            return
                context.Collection_Book.Where(e => e.CollectionID == collection.ID).ToList().Select(e => e.ToDalCollectionBook());
        }

        public DalQuote GetQuote(int id)
        {
            return context.Quotes.FirstOrDefault(e => e.QuoteID == id)?.ToDalQuote();
        }

        public IEnumerable<DalQuote> GetQuotes(DalCollectionBook cb)
        {
            return context.Quotes.Where(e => e.Collection_BookID == cb.ID).ToList().Select(e => e.ToDalQuote());
        }

        public IEnumerable<DalCollection> GetUserCollections(DalUser user)
        {
            return context.Collections.Where(e => e.UserID == user.ID).ToList().Select(e => e.ToDalCollection());
        }

        public void MoveBook(DalCollectionBook book, DalCollection collection)
        {
            var dbBook = context.Collection_Book.FirstOrDefault(e => e.Collection_BookID == book.ID);
            if (dbBook != null)
            {
                book.CollectionID = collection.ID;
            }
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
