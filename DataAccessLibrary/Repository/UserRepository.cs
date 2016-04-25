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
    public class UserRepository : IRepository<DalUser>
    {
        private readonly DbContext context;
        public UserRepository(DbContext context)
        {
            this.context = context;
        }
        public void Create(DalUser entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(DalUser entity)
        {
            throw new NotImplementedException();
        }

        public DalUser Find(Expression<Func<DalUser, bool>> f)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalUser> FindAll(Expression<Func<DalUser, bool>> f)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalUser> GetAll()
        {
            throw new NotImplementedException();
        }

        public DalUser GetById(int key)
        {
            throw new NotImplementedException();
        }

        public void Update(DalUser entity)
        {
            throw new NotImplementedException();
        }
    }
}
