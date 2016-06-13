using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfacies;
using Service.Interfacies;
using Service.Interfacies.Entities;
using ServiceLibrary.Mappers;

namespace ServiceLibrary.Service
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unit;
        public UserService(IUnitOfWork unit)
        {
            this.unit = unit;
        }

        public IEnumerable<ServiceRole> GetUserRoles(ServiceUser user)
        {
            return unit.Users.GetUserRoles(user.ToDalUser()).Select(e=>e.ToServiceRole());
        }

        public IEnumerable<ServiceRole> GetRoles()
        {
            return unit.Roles.GetAll().Select(e => e.ToServiceRole());
        }

        public ServiceUser Sign(ServiceUser user)
        {
            user.ID = unit.Users.Create(user.ToDalUser());
            unit.Users.AddUserRoles(user.ToDalUser(), user.Roles.Select(e=>e.ToDalRole()));
            unit.Save();
            return user;
        }

        public ServiceUser GetUserByEmail(string email)
        {
            var user = unit.Users.GetUserByEmail(email);
            if (user != null)
            {
                var roles = unit.Users.GetUserRoles(user);
                return user.ToServiceUser(roles);
            }
            return null;
        }

        public ServiceUser GetUserByLogin(string login)
        {
            var user =  unit.Users.GetUserByLogin(login);
            if (user != null)
            {
                var roles = unit.Users.GetUserRoles(user);
                return user.ToServiceUser(roles);
            }
            return null;
        }

        public ServiceUser GetUserById(int id)
        {
            var user = unit.Users.GetById(id);
            if (user != null)
            {
                var roles = unit.Users.GetUserRoles(user);
                return user.ToServiceUser(roles);
            }
            return null;
        }

        public void AddRole(ServiceRole role)
        {
            unit.Roles.Create(role.ToDalRole());
            unit.Save();
        }

        public ServiceUserProfile GetUserProfile(ServiceUser user)
        {
            return unit.Users.GetUserProfile(user.ToDalUser())?.ToServiceUserProfile();
        }

        public void UpdateUserProfile(ServiceUserProfile profile)
        {
            unit.Users.UpdateUserProfile(profile.ToDalUserProfile());
            unit.Save();
        }

        public ServiceUserProfile GetUserProfile(int id)
        {
            var user = unit.Users.GetById(id);
            return user != null ? unit.Users.GetUserProfile(user)?.ToServiceUserProfile() : null;
        }
    }
}
