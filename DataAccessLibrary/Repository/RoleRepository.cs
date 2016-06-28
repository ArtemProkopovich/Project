using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfacies;
using DataAccess.Interfacies.Entities;
using DataAccessLibrary.Mappers;
using ORMLibrary;
using System.Linq.Expressions;

namespace DataAccessLibrary.Repository
{
    public class RoleRepository : IRoleRepository
    {

        private readonly DatabaseContext context;
        public RoleRepository(DatabaseContext context)
        {
            this.context = context;
        }

        public int Create(DalRole entity)
        {
            var obj = entity.ToOrmRole();
            context.Roles.Add(obj);
            context.SaveChanges();
            return obj.RoleID;
        }

        public void Delete(DalRole entity)
        {
            var role = context.Roles.FirstOrDefault(e => e.RoleID == entity.ID);
            if (role != null)
                context.Roles.Remove(role);
        }

        public DalRole Find(Expression<Func<DalRole, bool>> f)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalRole> FindAll(Expression<Func<DalRole, bool>> f)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalRole> GetAll()
        {
            return context.Roles.ToList().Select(e => e.ToDalRole());
        }

        public DalRole GetById(int key)
        {
            return context.Roles.FirstOrDefault(e => e.RoleID == key)?.ToDalRole();
        }

        public void Update(DalRole entity)
        {
            var role = context.Roles.FirstOrDefault(e => e.RoleID == entity.ID);
            if (role != null)
            {
                role.Name = entity.Name;
                role.Priority = entity.Priority;
            }
        }
    }
}
