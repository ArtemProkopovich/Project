using DataAccess.Interfacies.Entities;
using Service.Interfacies.Entities;

namespace ServiceLibrary.Mappers
{
    public static class DalOrmRoleMapper
    {
        public static ServiceRole ToServiceRole(this DalRole role)
        {
            return new ServiceRole
            {
                ID = role.ID,
                Name = role.Name,
                Priority = role.Priority
            };
        }

        public static DalRole ToDalRole(this ServiceRole role)
        {
            return new DalRole
            {
                ID = role.ID,
                Name = role.Name,
                Priority = role.Priority
            };
        }
    }
}
