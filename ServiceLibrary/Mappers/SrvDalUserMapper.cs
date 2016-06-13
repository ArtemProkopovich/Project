using System.Collections.Generic;
using DataAccess.Interfacies.Entities;
using Service.Interfacies.Entities;
using System.Linq;

namespace ServiceLibrary.Mappers
{
    public static class DalOrmUserMapper
    {
        public static ServiceUser ToServiceUser(this DalUser user, IEnumerable<DalRole> roles)
        {
            return new ServiceUser
            {
                ID = user.ID,
                Email = user.Email,
                Login = user.Login,
                Password = user.Password,
                Roles = roles.Select(e=>e.ToServiceRole())
            };
        }

        public static DalUser ToDalUser(this ServiceUser user)
        {
            return new DalUser
            {
                ID = user.ID,
                Email = user.Email,
                Login = user.Login,
                Password = user.Password
            };
        }
    }
}
