using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Service.Interfacies.Entities;
using WebApplication.Models.BookModels;
using WebApplication.Models.ContentModels;
using WebApplication.Models.UserModels;

namespace WebApplication.Infrastructure.Mappers
{
    public static class CommentMapper
    {
        public static CommentModel ToCommentModel(this ServiceComment comment, UserShortModel user, BookShortModel book)
        {
            return new CommentModel
            {
                PublishTime = comment.PublishTime,
                Book = book,
                ID = comment.ID,
                Text = comment.Text,
                User = user
            };
        }

        public static ServiceComment ToServiceComment(this CommentModel comment)
        {
            return new ServiceComment
            {
                PublishTime = comment.PublishTime,
                BookID = comment.Book.ID,
                ID = comment.ID,
                Text = comment.Text,
                UserID = comment.User.ID
            };
        }
    }
}