using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service.Interfacies;
using Service.Interfacies.Entities;
using WebApplication.Infrastructure.Mappers;
using WebApplication.Models.BookModels;
using WebApplication.Models.ContentModels;
using WebApplication.Models.UserModels;

namespace WebApplication.Models.DataModels
{
    public class Content
    {
        private static readonly IServiceManager manager = DependencyResolver.Current.GetService<IServiceManager>();

        public static ContentModel GetContentModel(ServiceContent content)
        {
            UserShortModel user = manager.userService.GetUserProfile(content.UserID)?.ToUserShortModel() ??
                                  new ServiceUserProfile() { ID = content.UserID }.ToUserShortModel();
            return content.ToContentModel(user, Book.GetBookShortModel(content.BookID, content.UserID));
        }

        public static IEnumerable<ContentModel> GetContentModels(int bookID)
        {
            var book = manager.bookService.GetBookById(bookID);
            return manager.commentService.GetBookContents(book).Select(GetContentModel);
        }

        public static ServiceContent GetServiceContent(ContentModel model)
        {
            return model.ToServiceContent();
        }
    }
}