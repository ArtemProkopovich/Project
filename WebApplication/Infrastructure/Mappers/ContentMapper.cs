using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Service.Interfacies.Entities;
using WebApplication.Models.BookModels;
using WebApplication.Models.ContentModels;
using WebApplication.Models.UserModels;

namespace WebApplication.Infrastructure.Mappers
{
    public static class ContentMapper
    {
        public static ContentModel ToContentModel(this ServiceContent content, UserShortModel user, BookShortModel book)
        {
            return new ContentModel
            {
                Book = book,
                ID = content.ID,
                Text = content.Text,
                User = user
            };
        }

        public static ServiceContent ToServiceContent(this ContentModel content)
        {
            return new ServiceContent
            {
                BookID = content.Book.ID,
                ID = content.ID,
                Text = content.Text,
                UserID = content.User.ID
            };
        }
    }
}