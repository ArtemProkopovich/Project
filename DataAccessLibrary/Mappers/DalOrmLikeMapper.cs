using DataAccess.Interfacies.Entities;
using ORMLibrary;

namespace DataAccessLibrary.Mappers
{
    public static class DalOrmLikeMapper
    {
        public static Likes ToOrmLike(this DalLike like)
        {
            return new Likes
            {
                LikeID = like.ID,
                BookID = like.BookID,
                UserID = like.UserID,
                Like = like.Like
            };
        }

        public static DalLike ToDalLike(this Likes like)
        {
            return new DalLike
            {
                ID = like.LikeID,
                BookID = like.BookID,
                UserID = like.UserID,
                Like = like.Like
            };
        }
    }
}
