using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Models.AuthorModels;
using WebApplication.Models.BookModels;

namespace WebApplication.Models.ViewModels.FindModels
{
    public class FindIndexModel
    {
        public string Query { get; set; }
        public IEnumerable<BookShortModel> Books { get; set; }
        public IEnumerable<AuthorShortModel> Authors { get; set; }
    }
}