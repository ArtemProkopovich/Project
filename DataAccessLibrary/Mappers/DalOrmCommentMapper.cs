using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfacies.Entities;
using ORMLibrary;

namespace DataAccessLibrary.Mappers
{
    public static class DalOrmCommentMapper
    {
        public static Comments ToOrmComment(this DalComment comment)
        {
            return new Comments
            {
                CommentID = comment.ID,
                BookID = comment.BookID,
                UserID = comment.UserID,
                Text = comment.Text
            };
        }

        public static DalComment ToDalComment(this Comments comment)
        {
            return new DalComment
            {
                ID = comment.CommentID, 
                BookID = comment.BookID,
                UserID = comment.UserID,
                Text = comment.Text
            };
        }
    }
}
