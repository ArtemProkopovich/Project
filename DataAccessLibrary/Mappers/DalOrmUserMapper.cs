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
                Level = user.Level,
                Login = user.Login,
                Name = user.Name,
                Phone = user.Phone,
                Password = user.Password,
                Surname = user.Surname
            };
        }

        public static DalUser ToDalUser(this Users user)
        {
            return new DalUser
            {
                ID = user.UserID,
                Email = user.Email,
                Level = user.Level ?? 0,
                Login = user.Login,
                Name = user.Name,
                Surname = user.Surname,
                Phone = user.Phone,
                Password = user.Password
            };
        }
    }
}
