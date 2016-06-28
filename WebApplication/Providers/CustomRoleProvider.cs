using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using NLog;
using Service.Interfacies;
using Service.Interfacies.Entities;

namespace WebApplication.Providers
{
    public class CustomRoleProvider : RoleProvider
    {
        private Logger logger = LogManager.GetCurrentClassLogger();
        public IUserService userService = DependencyResolver.Current.GetService<IUserService>();

        public override void CreateRole(string roleName)
        {
            try
            {
                var newRole = new ServiceRole() {Name = roleName};
                userService.AddRole(newRole);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }
        public override string[] GetRolesForUser(string username)
        {
            try
            {
                var user = userService.GetUserByEmail(username) ?? userService.GetUserByLogin(username);
                if (user != null)
                {
                    return user.Roles.Select(e => e.Name).ToArray();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return new string[0];
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            try
            {
                var user = userService.GetUserByEmail(username) ?? userService.GetUserByLogin(username);
                if (user != null)
                {
                    return user.Roles.Any(e => e.Name == roleName);
                }
                return false;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return false;
        }

        #region NotImplemented methods
        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}