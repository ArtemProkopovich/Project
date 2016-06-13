using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Models.BookModels;

namespace WebApplication.Models.UserModels
{
    public class EditListModel
    {
        public ListModel List { get; set; }
        public IEnumerable<BookShortModel> ListBooks { get; set; }
        public IEnumerable<BookShortModel> OtherBooks { get; set; }
    }
}