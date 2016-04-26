using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfacies.Entities;
using ORMLibrary;

namespace DataAccessLibrary.Mappers
{
    public static class DalOrmBookmarkMapper
    {
        public static Bookmarks ToOrmBookmark(this DalBookmark bookmark)
        {
            return new Bookmarks
            {
                BookmarkID = bookmark.ID,
                Page = bookmark.Page,
                Collection_BookID = bookmark.CollectionBookID,
            };
        }

        public static DalBookmark ToDalBookmark(this Bookmarks bookmark)
        {
            return new DalBookmark
            {
                ID = bookmark.BookmarkID,
                Page = bookmark.Page,
                CollectionBookID = bookmark.Collection_BookID,
            };
        }
    }
}
