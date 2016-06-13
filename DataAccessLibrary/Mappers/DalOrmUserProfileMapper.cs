using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfacies.Entities;
using ORMLibrary;

namespace DataAccessLibrary.Mappers
{
    public static class DalOrmUserProfileMapper
    {
        public static UserProfiles ToOrmUserProfile(this DalUserProfile profile)
        {
            return new UserProfiles
            {
                UserID = profile.ID,
                Name = profile.Name,
                Surname = profile.Surname,
                Male = profile.Male,
                Photo_Path = profile.PhotoPath,
                BirthDate = profile.BirthDate,
                Level = profile.Level,
                Points = profile.Points
            };
        }

        public static DalUserProfile ToDalUserProfile(this UserProfiles profile)
        {
            return new DalUserProfile
            {
                ID = profile.UserID,
                Name = profile.Name,
                Surname = profile.Surname,
                Male = profile.Male ?? true,
                PhotoPath = profile.Photo_Path,
                BirthDate = profile.BirthDate ?? DateTime.Now,
                Level = profile.Level ?? 0,
                Points = profile.Points ?? 0
            };
        }
    }
}
