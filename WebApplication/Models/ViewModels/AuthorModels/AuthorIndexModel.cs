using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Models.AuthorModels;

namespace WebApplication.Models.ViewModels.AuthorModels
{
    public class AuthorIndexModel
    {
        public int bookOnPageCount { get; set; }
        public int pageCount { get; set; }
        public int currentPage { get; set; }
        public IEnumerable<AuthorShortModel> Authors { get; set; }
    }
}