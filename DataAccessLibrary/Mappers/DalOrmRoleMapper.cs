using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfacies.Entities;
using ORMLibrary;

namespace DataAccessLibrary.Mappers
{
    public static class DalOrmRoleMapper
    {
        public static Roles ToOrmRole(this DalRole role)
        {
            return new Roles
            {
                RoleID = role.ID,
                Name = role.Name,
                Priority = role.Priority
            };
        }

        public static DalRole ToDalRole(this Roles role)
        {
            return new DalRole
            {
                ID = role.RoleID,
                Name = role.Name,
                Priority = role.Priority
            };
        }
    }
}
