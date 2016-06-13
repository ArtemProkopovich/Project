using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfacies.Entities;

namespace DataAccess.Interfacies
{
    public interface IUserRepository : IRepository<DalUser>
    {
        DalUser GetUserByEmail(string email);
        DalUser GetUserByLogin(string login);
        DalUserProfile GetUserProfile(DalUser user);
        void UpdateUserProfile(DalUserProfile profile);
        IEnumerable<DalRole> GetUserRoles(DalUser user);
        void AddUserRole(DalUser user, DalRole role);
        void AddUserRoles(DalUser user, IEnumerable<DalRole> roles);
        void DeleteUserRole(DalUser user, DalRole role);
    }
}
