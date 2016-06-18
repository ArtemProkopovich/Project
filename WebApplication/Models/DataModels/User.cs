using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service.Interfacies;
using WebApplication.Infrastructure.Mappers;
using WebApplication.Models.UserModels;
using WebApplication.Models.ViewModels.UserModels;

namespace WebApplication.Models.DataModels
{
    public class User
    {
        public static readonly IServiceManager manager = DependencyResolver.Current.GetService<IServiceManager>();

        public static UserIndexModel GetUserIndexModel(int id)
        {
            var serviceUser = manager.userService.GetUserById(id);
            if (serviceUser != null)
            {
                UserIndexModel result = new UserIndexModel();
                result.Profile = GetUserProfileModel(id);
                result.CollectionCount = manager.collectionService.GetUserCollections(serviceUser).Count();
                result.CommentCount = manager.commentService.GetUserComments(serviceUser).Count();
                re
                return result;
            }
            return null;
        }

        public static UserProfileModel GetUserProfileModel(int id)
        {
            return manager.userService.GetUserProfile(id).ToUserProfileModel();
        }
    }
}