using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Service.Interfacies.Entities;
using WebApplication.Infrastructure.Mappers;
using WebApplication.Models.ViewModels.ContentModels;

namespace WebApplication.Models.DataModels
{
    public class Bookmark
    {
        public static BookmarkModel GetBookmarkModel(ServiceBookmark bm)
        {
            return bm.ToBookmarkModel();
        }
    }
}