using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Service.Interfacies.Entities;
using WebApplication.Models.UserModels;

namespace WebApplication.Infrastructure.Mappers
{
    public static class UserMapper
    {
        public static UserProfileModel ToUserProfileModel(this ServiceUserProfile profile)
        {
            return new UserProfileModel()
            {
                ID = profile.ID,
                BirthDate = profile.BirthDate,
                Level = profile.Level,
                Male = profile.Male,
                Name = profile.Name,
                Surname = profile.Surname,
                PhotoPath = profile.PhotoPath,
                Points = profile.Points
            };
        }

        public static ServiceUserProfile ToServiceUserProfile(this UserProfileModel model)
        {
            return new ServiceUserProfile()
            {
                ID = model.ID,
                BirthDate = model.BirthDate,
                Level = model.Level,
                Male = model.Male ?? true,
                Name = model.Name,
                Surname = model.Surname,
                PhotoPath = model.PhotoPath,
                Points = model.Points
            };
        }
    }
}