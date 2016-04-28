using DataAccess.Interfacies.Entities;
using Service.Interfacies.Entities;

namespace ServiceLibrary.Mappers
{
    public static class DalOrmLikeMapper
    {
        public static ServiceLike ToServiceLike(this DalLike like)
        {
            return new ServiceLike
            {
                ID = like.ID,
                BookID = like.BookID,
                UserID = like.UserID,
                Like = like.Like
            };
        }

        public static DalLike ToDalLike(this ServiceLike like)
        {
            return new DalLike
            {
                ID = like.ID,
                BookID = like.BookID,
                UserID = like.UserID,
                Like = like.Like
            };
        }
    }
}
