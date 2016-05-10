using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Models.BookModels
{
    public class BookShortModel
    {
        [HiddenInput(DisplayValue = false)]
        public int ID { get; set; }
        public string Name { get; set; }
        public List<string> Authors { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public string Cover { get; set; }
    }
}