using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models.ViewModels.ContentModels
{
    public class BookmarkModel
    {
        public int ID { get; set; }
        public int CollectionBookID { get; set; }
        public int Page { get; set; }
    }
}