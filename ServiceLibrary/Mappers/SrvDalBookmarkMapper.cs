using DataAccess.Interfacies.Entities;
using Service.Interfacies.Entities;

namespace ServiceLibrary.Mappers
{
    public static class DalOrmBookmarkMapper
    {
        public static ServiceBookmark ToServiceBookmark(this DalBookmark bookmark)
        {
            return new ServiceBookmark
            {
                ID = bookmark.ID,
                Page = bookmark.Page,
                CollectionBookID = bookmark.CollectionBookID,
            };
        }

        public static DalBookmark ToDalBookmark(this ServiceBookmark bookmark)
        {
            return new DalBookmark
            {
                ID = bookmark.ID,
                Page = bookmark.Page,
                CollectionBookID = bookmark.CollectionBookID,
            };
        }
    }
}
