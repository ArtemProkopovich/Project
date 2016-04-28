using DataAccess.Interfacies.Entities;
using Service.Interfacies.Entities;

namespace ServiceLibrary.Mappers
{
    public static class DalOrmUserMapper
    {
        public static ServiceUser ToServiceUser(this DalUser user)
        {
            return new ServiceUser
            {
                ID = user.ID,
                Email = user.Email,
                Level = user.Level,
                Login = user.Login,
                Name = user.Name,
                Phone = user.Phone,
                Password = user.Password,
                Surname = user.Surname
            };
        }

        public static DalUser ToDalUser(this ServiceUser user)
        {
            return new DalUser
            {
                ID = user.ID,
                Email = user.Email,
                Level = user.Level,
                Login = user.Login,
                Name = user.Name,
                Surname = user.Surname,
                Phone = user.Phone,
                Password = user.Password
            };
        }
    }
}
