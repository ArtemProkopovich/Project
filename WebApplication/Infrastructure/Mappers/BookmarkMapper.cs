using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Service.Interfacies.Entities;
using WebApplication.Models.ViewModels.ContentModels;

namespace WebApplication.Infrastructure.Mappers
{
    public static class BookmarkMapper
    {
        public static BookmarkModel ToBookmarkModel(this ServiceBookmark bm)
        {
            return new BookmarkModel()
            {
                ID = bm.ID,
                CollectionBookID = bm.CollectionBookID,
                Page = bm.Page
            };
        }

        public static ServiceBookmark ToServiceBookmark(this BookmarkModel bm)
        {
            return new ServiceBookmark()
            {
                ID = bm.ID,
                CollectionBookID = bm.CollectionBookID,
                Page = bm.Page
            };
        }
    }
}