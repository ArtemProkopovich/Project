using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Service.Interfacies.Entities;
using WebApplication.Models.ContentModels;
using WebApplication.Models.UserModels;

namespace WebApplication.Infrastructure.Mappers
{
    public static class CommentMapper
    {
        public static CommentModel ToCommentModel(this ServiceComment comment, UserShortModel user)
        {
            return new CommentModel
            {
                PublishTime = comment.PublishTime,
                BookID = comment.BookID,
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
                BookID = comment.BookID,
                ID = comment.ID,
                Text = comment.Text,
                UserID = comment.User.ID
            };
        }
    }
}