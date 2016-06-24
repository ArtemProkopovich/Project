using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Service.Interfacies.Entities;
using WebApplication.Models.CollectionBookModels;
using WebApplication.Models.Shared;
using WebApplication.Models.ViewModels.ContentModels;

namespace WebApplication.Models.ViewModels.CollectionBookModels
{
    public class CollectionBookPageModel : _UserProfileModel
    {
        public CollectionBookPageModel(_UserProfileModel profile):base(profile)
        {
        }
        public CollectionBookModel Book { get; set; }
        public IEnumerable<QuoteModel> Quotes { get; set; }
        public IEnumerable<BookmarkModel> Bookmarks { get; set; }
        public IEnumerable<ServiceFile> Files { get; set; }
    }
}