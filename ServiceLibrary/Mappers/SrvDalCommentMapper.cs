using DataAccess.Interfacies.Entities;
using Service.Interfacies.Entities;

namespace ServiceLibrary.Mappers
{
    public static class DalOrmCommentMapper
    {
        public static ServiceComment ToServiceComment(this DalComment comment)
        {
            return new ServiceComment
            {
                ID = comment.ID,
                BookID = comment.BookID,
                UserID = comment.UserID,
                Text = comment.Text
            };
        }

        public static DalComment ToDalComment(this ServiceComment comment)
        {
            return new DalComment
            {
                ID = comment.ID, 
                BookID = comment.BookID,
                UserID = comment.UserID,
                Text = comment.Text
            };
        }
    }
}
