using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfacies.Entities;

namespace DataAccess.Interfacies
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int key);
        TEntity Find(Expression<Func<TEntity, bool>> f);
        IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> f);
        int Create(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
    }
}
