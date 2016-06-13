using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Interfacies.Entities;

namespace Service.Interfacies
{
    public interface IUserService
    {
        ServiceUser Sign(ServiceUser user);
        ServiceUser GetUserByEmail(string email);
        ServiceUser GetUserByLogin(string login);
        ServiceUser GetUserById(int id);
        ServiceUserProfile GetUserProfile(ServiceUser user);
        ServiceUserProfile GetUserProfile(int id);
        void UpdateUserProfile(ServiceUserProfile profile);
        void AddRole(ServiceRole role);
        IEnumerable<ServiceRole> GetUserRoles(ServiceUser user);
        IEnumerable<ServiceRole> GetRoles();
    }
}
