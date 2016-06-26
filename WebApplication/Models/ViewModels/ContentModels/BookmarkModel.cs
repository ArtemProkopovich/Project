using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Models.ViewModels.ContentModels
{
    public class BookmarkModel
    {
        [HiddenInput]
        public int ID { get; set; }
        [HiddenInput]
        public int CollectionBookID { get; set; }
        [Required(AllowEmptyStrings =false)]
        public int Page { get; set; }
    }
}