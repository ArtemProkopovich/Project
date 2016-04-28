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

        public void Exit(ServiceUser user)
        {
            throw new NotImplementedException();
        }

        public ServiceRole GetUserRole(ServiceUser user)
        {
            return unit.Users.GetUserRoles(user.ToDalUser())?.First()?.ToServiceRole();
        }

        public ServiceUser Login(ServiceLoginAuthorizeUser user)
        {
            throw new NotImplementedException();
        }

        public ServiceUser Login(ServiceEmailAuthorizeUser user)
        {
            throw new NotImplementedException();
        }

        public ServiceUser Sign(ServiceUser user)
        {
            unit.Users.Create(user.ToDalUser());
            return user;
        }
    }
}
