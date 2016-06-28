using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfacies;
using DataAccess.Interfacies.Entities;
using DataAccessLibrary.Additional;
using DataAccessLibrary.Mappers;
using ORMLibrary;

namespace DataAccessLibrary.Repository
{
    public class ListRepository : IListRepository
    {
        private readonly DatabaseContext context;
        public ListRepository(DatabaseContext context)
        {
            this.context = context;
        }

        public void AddBook(DalList list, DalBook book)
        {
            var dbList = context.Lists.FirstOrDefault(e => e.ListID == list.ID);
            var dbBook = context.Books.FirstOrDefault(e => e.BookID == book.ID);
            if (dbList != null && dbBook != null)
            {
                dbBook.Lists.Add(dbList);
                context.SaveChanges();
            }
        }

        public void AddBooks(DalList list, IEnumerable<DalBook> books)
        {
            foreach (var book in books)
                AddBook(list, book);
        }

        public int Create(DalList entity)
        {
            var obj = entity.ToOrmList();
            context.Lists.Add(obj);
            context.SaveChanges();
            return obj.ListID;
        }

        public void Delete(DalList entity)
        {
            var t = context.Lists.FirstOrDefault(e => e.ListID == entity.ID);
            if (t != null)
                context.Lists.Remove(t);
        }

        public void DeleteBook(DalList list, DalBook book)
        {
            var dbList = context.Lists.FirstOrDefault(e => e.ListID == list.ID);
            var dbBook = context.Books.FirstOrDefault(e => e.BookID == book.ID);
            if (dbList != null && dbBook != null)
            {
                dbList.Books.Remove(dbBook);
                context.SaveChanges();
            }
        }

        public DalList Find(Expression<Func<DalList, bool>> f)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalList> FindAll(Expression<Func<DalList, bool>> f)
        {
            var lambda = ExpressionTranslator.Translate<DalList, Lists>(f, new Dictionary<string, string>());
            return context.Lists.Where(lambda).ToList().Select(e => e.ToDalList());
        }

        public IEnumerable<DalList> GetAll()
        {
            var lists = context.Lists.ToList();
            return lists.Select(e => e.ToDalList());
        }

        public IEnumerable<DalBook> GetBooks(DalList list)
        {
            return context.Lists.FirstOrDefault(e => e.ListID == list.ID)?.Books.Select(e => e.ToDalBook());
        }

        public DalList GetById(int key)
        {
            return context.Lists.FirstOrDefault(e => e.ListID == key)?.ToDalList();
        }

        public void Update(DalList entity)
        {
            var g = context.Lists.FirstOrDefault(e => e.ListID == entity.ID);
            if (g != null)
            {
                g.Name = entity.Name;
            }
        }
    }
}
