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
    public class UserRepository : IUserRepository
    {
        private readonly ProjectDataEntities context;
        public UserRepository(ProjectDataEntities context)
        {
            this.context = context;
        }

        public void AddUserRole(DalUser user, DalRole role)
        {
            var dbUser = context.Users.FirstOrDefault(e => e.UserID == user.ID);
            var dbRole = context.Roles.FirstOrDefault(e => e.RoleID == role.ID);
            if (dbUser != null && dbRole != null)
            {
                dbUser.Roles.Add(dbRole);
            }
        }

        public void Create(DalUser entity)
        {
            context.Users.Add(entity.ToOrmUser());
        }

        public void Delete(DalUser entity)
        {
            var u = context.Users.FirstOrDefault(e => e.UserID == entity.ID);
            if (u != null)
                context.Users.Remove(u);
        }

        public void DeleteUserRole(DalUser user, DalRole role)
        {
            var dbUser = context.Users.FirstOrDefault(e => e.UserID == user.ID);
            var dbRole = context.Roles.FirstOrDefault(e => e.RoleID == role.ID);
            if (dbUser != null && dbRole != null)
            {
                dbUser.Roles.Remove(dbRole);
            }
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
            return context.Users.Select(e => e.ToDalUser());
        }

        public DalUser GetById(int key)
        {
            return context.Users.FirstOrDefault(e => e.UserID == key)?.ToDalUser();
        }

        public IEnumerable<DalRole> GetUserRoles(DalUser user)
        {
            var dbUser = context.Users.FirstOrDefault(e => e.UserID == user.ID);
            if (dbUser != null)
            {
                return dbUser.Roles.Select(e => e.ToDalRole());
            }
            return new List<DalRole>();
        }

        public void Update(DalUser entity)
        {
            var u = context.Users.FirstOrDefault(e => e.UserID == entity.ID);
            if (u != null)
            {
                u.Name = entity.Name;
                u.Email = entity.Email;
                u.Level = entity.Level;
                u.Login = entity.Login;
                u.Name = entity.Name;
                u.Password = entity.Password;
                u.Phone = entity.Phone;
                u.Surname = entity.Surname;
            }
        }
    }
}
