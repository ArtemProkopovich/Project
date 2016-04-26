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
        IEnumerable<DalRole> GetUserRoles(DalUser user);
        void AddUserRole(DalUser user, DalRole role);
        void DeleteUserRole(DalUser user, DalRole role);
    }
}
