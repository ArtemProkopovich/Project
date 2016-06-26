using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models.AuthorModels;
using WebApplication.Models.ViewModels.ContentModels;

namespace WebApplication.Models.BookModels
{
    public class BookShortModel
    {
        [HiddenInput(DisplayValue = false)]
        public int ID { get; set; }
        public string Name { get; set; }
        public AuthorShortModel Author { get; set; }
        public LikeButtonsModel Likes { get; set; }
        public string Cover { get; set; }
    }
}