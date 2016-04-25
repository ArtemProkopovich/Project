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

namespace DataAccessLibrary.Repository
{
    public class AuthorRepository : IRepository<DalAuthor>
    {
        private readonly DbContext context;
        public AuthorRepository(DbContext context)
        {
            this.context = context;
        }

        public void Create(DalAuthor entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(DalAuthor entity)
        {
            throw new NotImplementedException();
        }

        public DalAuthor Find(Expression<Func<DalAuthor, bool>> f)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalAuthor> FindAll(Expression<Func<DalAuthor, bool>> f)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalAuthor> GetAll()
        {
            throw new NotImplementedException();
        }

        public DalAuthor GetById(int key)
        {
            throw new NotImplementedException();
            context.Set<Authors>().Find(key);
        }

        public void Update(DalAuthor entity)
        {
            throw new NotImplementedException();
        }
    }
}
