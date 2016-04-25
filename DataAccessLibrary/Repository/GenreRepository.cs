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
    public class GenreRepository : IRepository<DalGenre>
    {
        private readonly DbContext context;
        public GenreRepository(DbContext context)
        {
            this.context = context;
        }
        public void Create(DalGenre entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(DalGenre entity)
        {
            throw new NotImplementedException();
        }

        public DalGenre Find(Expression<Func<DalGenre, bool>> f)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalGenre> FindAll(Expression<Func<DalGenre, bool>> f)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalGenre> GetAll()
        {
            throw new NotImplementedException();
        }

        public DalGenre GetById(int key)
        {
            throw new NotImplementedException();
        }

        public void Update(DalGenre entity)
        {
            throw new NotImplementedException();
        }
    }
}
