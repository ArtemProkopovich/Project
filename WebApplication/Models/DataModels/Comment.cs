using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service.Interfacies;
using Service.Interfacies.Entities;
using WebApplication.Infrastructure.Mappers;
using WebApplication.Models.ContentModels;
using WebApplication.Models.UserModels;

namespace WebApplication.Models.DataModels
{
    public class Comment
    {
        private static readonly IServiceManager manager = DependencyResolver.Current.GetService<IServiceManager>();

        public static CommentModel GetCommentModel(ServiceComment comment)
        {
            UserShortModel user = manager.userService.GetUserProfile(comment.UserID)?.ToUserShortModel() ??
                                  new ServiceUserProfile() {ID = comment.UserID}.ToUserShortModel();
            return comment.ToCommentModel(user);
        }

        public static ServiceComment GetServiceComment(CommentModel model)
        {
            return model.ToServiceComment();
        }
    }
}