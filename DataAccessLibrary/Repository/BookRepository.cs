using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfacies;
using DataAccess.Interfacies.Entities;

namespace DataAccessLibrary.Repository
{
    public class BookRepository : IRepository<DalBook>
    {
        private readonly DbContext context;
        public BookRepository(DbContext context)
        {
            this.context = context;
        }
        public void Create(DalBook entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(DalBook entity)
        {
            throw new NotImplementedException();
        }

        public DalBook Find(Expression<Func<DalBook, bool>> f)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalBook> FindAll(Expression<Func<DalBook, bool>> f)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalBook> GetAll()
        {
            throw new NotImplementedException();
        }

        public DalBook GetById(int key)
        {
            throw new NotImplementedException();
        }

        public void Update(DalBook entity)
        {
            throw new NotImplementedException();
        }
    }
}
