using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfacies.Entities;
using Service.Interfacies.Entities;

namespace ServiceLibrary.Mappers
{
    public static class SrvDalUserProfileMapper
    {
        public static DalUserProfile ToDalUserProfile(this ServiceUserProfile profile)
        {
            return new DalUserProfile
            {
                ID = profile.ID,
                Name = profile.Name,
                Surname = profile.Surname,
                Male = profile.Male,
                PhotoPath = profile.PhotoPath,
                BirthDate = profile.BirthDate,
                Level = profile.Level,
                Points = profile.Points
            };
        }

        public static ServiceUserProfile ToServiceUserProfile(this DalUserProfile profile)
        {
            return new ServiceUserProfile
            {
                ID = profile.ID,
                Name = profile.Name,
                Surname = profile.Surname,
                Male = profile.Male,
                PhotoPath = profile.PhotoPath,
                BirthDate = profile.BirthDate,
                Level = profile.Level,
                Points = profile.Points
            };
        }
    }
}
