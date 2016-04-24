using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfacies.Entities;

namespace DataAccess.Interfacies.Interfacies
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        IEnumerable<TEntity> ReadAll();
        TEntity ReadById(int key);
        TEntity Find(Expression<Func<TEntity, bool>> f);
        IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> f);
        void Create(TEntity e);
        void Delete(TEntity e);
        void Update(TEntity entity);
    }
}
