using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Models.BookModels;

namespace WebApplication.Models.ViewModels.BookModels
{

    public enum SortBy
    {
        Likes,
        Comments,
        Read,
    }

    public class BookListModel
    {
        public SortBy Filter { get; set; }
        public int bookOnPageCount { get; set; }
        public int pageCount { get; set; }
        public int currentPage { get; set; }
        public IEnumerable<BookShortModel> Books { get; set; }
    }
}