using DataAccess.Interfacies.Entities;
using Service.Interfacies.Entities;

namespace ServiceLibrary.Mappers
{
    public static class DalOrmCoverMapper
    {
        public static ServiceCover ToServiceCover(this DalCover cover)
        {
            return new ServiceCover
            {
                ID = cover.ID,
                BookID = cover.BookID,
                ImagePath = cover.ImagePath
            };
        }

        public static DalCover ToDalCover(this ServiceCover cover)
        {
            return new DalCover
            {
                ID = cover.ID,
                BookID = cover.BookID,
                ImagePath = cover.ImagePath
            };
        }
    }
}
