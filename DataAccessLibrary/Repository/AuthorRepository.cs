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
    public class AuthorRepository : IRepository<DalAuthor>
    {
        private readonly DbContext context;
        public AuthorRepository(DbContext context)
        {
            this.context = context;
        }

        public void Create(DalAuthor entity)
        {
            context.Set<Authors>().Add(entity.ToOrmAuthor());
        }

        public void Delete(DalAuthor entity)
        {
            var el = context.Set<Authors>().Single(e => e.AuthorID == entity.ID);
            context.Set<Authors>().Remove(el);
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
            return context.Set<Authors>().Select(e => e.ToDalAuthor());
        }

        public DalAuthor GetById(int key)
        {
            return context.Set<Authors>().Find(key).ToDalAuthor();
        }

        public void Update(DalAuthor entity)
        {
            context.Entry(entity.ToOrmAuthor()).State = EntityState.Modified;

        }
    }
}
