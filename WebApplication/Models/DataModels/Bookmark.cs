using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service.Interfacies;
using Service.Interfacies.Entities;
using WebApplication.Infrastructure.Mappers;
using WebApplication.Models.ViewModels.ContentModels;

namespace WebApplication.Models.DataModels
{
    public class Bookmark
    {
        private static readonly IServiceManager manager = DependencyResolver.Current.GetService<IServiceManager>();
        public static BookmarkModel GetBookmarkModel(ServiceBookmark bm)
        {
            return bm.ToBookmarkModel();
        }

        public static IEnumerable<BookmarkModel> GetBookmarkList(int id)
        {
            var cb = manager.collectionService.GetCollectionBookById(id);
            return manager.collectionService.GetBookmarks(cb).Select(GetBookmarkModel);
        }
    }
}