using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models.BookModels;
using WebApplication.Models.UserModels;

namespace WebApplication.Models.ContentModels
{
    public class ContentModel
    {
        public int ID { get; set; }
        public BookShortModel Book { get; set; }
        public UserShortModel User { get; set; }
        [AllowHtml]
        public string Text { get; set; }
    }
}