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
    public class CollectionRepository : IRepository<DalCollection>
    {
        private readonly DbContext context;
        public CollectionRepository(DbContext context)
        {
            this.context = context;
        }
        public void Create(DalCollection entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(DalCollection entity)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public DalCollection GetById(int key)
        {
            throw new NotImplementedException();
        }

        public void Update(DalCollection entity)
        {
            throw new NotImplementedException();
        }
    }
}
