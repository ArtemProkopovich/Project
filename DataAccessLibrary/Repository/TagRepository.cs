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
    public class TagRepository : IRepository<DalTag>
    {
        private readonly DbContext context;
        public TagRepository(DbContext context)
        {
            this.context = context;
        }
        public void Create(DalTag entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(DalTag entity)
        {
            throw new NotImplementedException();
        }

        public DalTag Find(Expression<Func<DalTag, bool>> f)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalTag> FindAll(Expression<Func<DalTag, bool>> f)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalTag> GetAll()
        {
            throw new NotImplementedException();
        }

        public DalTag GetById(int key)
        {
            throw new NotImplementedException();
        }

        public void Update(DalTag entity)
        {
            throw new NotImplementedException();
        }
    }
}
