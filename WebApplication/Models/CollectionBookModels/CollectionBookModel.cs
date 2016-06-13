using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models.BookModels;
using WebApplication.Models.CollectionModels;

namespace WebApplication.Models.CollectionBookModels
{
    public class CollectionBookModel
    {
        [HiddenInput(DisplayValue = false)]
        public int ID { get; set; }
        public CollectionModel collection { get; set; }
        public BookShortModel book { get; set; }
        public bool? IsRead { get; set; }
    }
}