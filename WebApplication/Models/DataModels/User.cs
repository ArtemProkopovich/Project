using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service.Interfacies;
using Service.Interfacies.Entities;
using WebApplication.Infrastructure.Mappers;
using WebApplication.Models.Shared;
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
                var collections = manager.collectionService.GetUserCollections(serviceUser);
                var books = new List<ServiceCollectionBook>();
                int count = 0;
                foreach (var cl in collections)
                {
                    count++;
                    books = books.Union(manager.collectionService.GetCollectionBooks(cl), new CollectionBook()).ToList();
                }
                result.BookCount = books.Count;
                result.CollectionCount = count;
                result.CommentCount = manager.commentService.GetUserComments(serviceUser).Count();
                result.ContentCount = manager.commentService.GetUserContents(serviceUser).Count();
                result.ReviewCount = manager.commentService.GetUserReviews(serviceUser).Count();
                return result;
            }
            return null;
        }

        public static UserContentDetailsModel GetUserContentDetailsModel(int id)
        {
            var user = manager.userService.GetUserById(id);
            var profile = manager.userService.GetUserProfile(id);
            UserContentDetailsModel model = new UserContentDetailsModel();
            model.Comments = manager.commentService.GetUserComments(user).Select(Comment.GetCommentModel);
            model.Reviews = manager.commentService.GetUserReviews(user).Select(Review.GetReviewModel);
            model.Contents = manager.commentService.GetUserContents(user).Select(Content.GetContentModel);
            model.ID = user.ID;
            model.Name = profile.Name;
            model.Surname = profile.Surname;
            model.PhotoPath = profile.PhotoPath;
            return model;
        }

        public static UserProfileModel GetUserProfileModel(int id)
        {
            return manager.userService.GetUserProfile(id).ToUserProfileModel();
        }

        public static _UserProfileModel Get_UserProfileModel(int id)
        {
            return manager.userService.GetUserProfile(id).To_UserProfileModel();
        }
    }
}