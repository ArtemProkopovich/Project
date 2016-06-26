using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Service.Interfacies.Entities;
using WebApplication.Models;
using WebApplication.Models.BookModels;
using WebApplication.Models.DataModels;

namespace WebApplication.Infrastructure.Mappers
{
    public static class TagMapper
    {
        public static ServiceTag ToServiceTag(this TagModel tag)
        {
            return new ServiceTag
            {
                ID = tag.ID,
                Name = tag.Name
            };
        }

        public static TagModel ToTagModel(this ServiceTag tag, int bookCount)
        {
            return new TagModel
            {
                ID = tag.ID,
                Name = tag.Name,
                BookCount = bookCount
            };
        }

        public static TagBookListModel ToTagBookListModel(this ServiceTag tag, IEnumerable<BookShortModel> books)
        {
            return new TagBookListModel
            {
                Tag = Tag.GetTagModel(tag),
                Books = books
            };
        }
    }
}