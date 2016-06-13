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
        private readonly DatabaseContext context;
        public UserRepository(DatabaseContext context)
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

        public void AddUserRoles(DalUser user, IEnumerable<DalRole> roles)
        {
            foreach (var role in roles)
                AddUserRole(user, role);
        }

        public int Create(DalUser entity)
        {
            var obj = entity.ToOrmUser();
            context.Users.Add(obj);
            context.SaveChanges();
            return obj.UserID;
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
            return context.Users.ToList().Select(e => e.ToDalUser());
        }

        public DalUser GetById(int key)
        {
            return context.Users.FirstOrDefault(e => e.UserID == key)?.ToDalUser();
        }

        public DalUser GetUserByEmail(string email)
        {
            return context.Users.FirstOrDefault(e => e.Email == email)?.ToDalUser();
        }

        public DalUser GetUserByLogin(string login)
        {
            return context.Users.FirstOrDefault(e => e.Login == login)?.ToDalUser();
        }

        public DalUserProfile GetUserProfile(DalUser user)
        {
            return context.UserProfiles.FirstOrDefault(e => e.UserID == user.ID)?.ToDalUserProfile();
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
                u.Email = entity.Email;
                u.Login = entity.Login;
                u.Password = entity.Password;
            }
        }

        public void UpdateUserProfile(DalUserProfile profile)
        {
            var dbProfile = context.UserProfiles.FirstOrDefault(e => e.UserID == profile.ID);
            var dbUser = context.Users.FirstOrDefault(e => e.UserID == profile.ID);
            if (dbUser == null)
                return;
            if (dbProfile == null)
                context.UserProfiles.Add(profile.ToOrmUserProfile());
            else
            {
                dbProfile.BirthDate = profile.BirthDate;
                dbProfile.Level = profile.Level;
                dbProfile.Male = profile.Male;
                dbProfile.Name = profile.Name;
                dbProfile.Photo_Path = profile.PhotoPath;
                dbProfile.Points = profile.Points;
                dbProfile.Surname = profile.Surname;
            }
        }
    }
}
