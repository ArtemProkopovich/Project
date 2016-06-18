using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Models.AuthorModels;

namespace WebApplication.Models.BookModels
{
    public class BookIndexPageModel
    {
        public IEnumerable<BookShortModel> Books { get; set; }
        public IEnumerable<AuthorShortModel> Authors { get; set; }
        public IEnumerable<GenreFirstModel> Genres { get; set; }
        public IEnumerable<ListFirstModel> Lists { get; set; }
    }
}