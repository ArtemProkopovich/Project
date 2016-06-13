using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfacies.Entities;
using ORMLibrary;

namespace DataAccessLibrary.Mappers
{
    public static class DalOrmUserMapper
    {
        public static Users ToOrmUser(this DalUser user)
        {
            return new Users
            {
                UserID = user.ID,
                Email = user.Email,
                Login = user.Login,
                Password = user.Password,
            };
        }

        public static DalUser ToDalUser(this Users user)
        {
            return new DalUser
            {
                ID = user.UserID,
                Email = user.Email,
                Login = user.Login,
                Password = user.Password
            };
        }
    }
}
