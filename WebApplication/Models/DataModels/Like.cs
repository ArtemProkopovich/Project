using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service.Interfacies;
using Service.Interfacies.Entities;
using WebApplication.Models.ViewModels.ContentModels;

namespace WebApplication.Models.DataModels
{
    public class Like
    {
        private static readonly IServiceManager manager = DependencyResolver.Current.GetService<IServiceManager>();
        public static LikeButtonsModel GetLikeButtonsModel(int bookID, int userID)
        {
            LikeButtonsModel result = new LikeButtonsModel();
            var book = manager.bookService.GetBookById(bookID);
            result.BookID = bookID;
            var likes = manager.bookService.GetBookLikes(book) ?? new List<ServiceLike>();
            result.Likes = likes.Count(e => e.Like);
            result.Dislikes = likes.Count(e => !e.Like);
            result.UserLike = likes.FirstOrDefault(e => e.UserID == userID);
            return result;
        }
    }
}