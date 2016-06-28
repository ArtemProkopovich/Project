using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Models.ViewModels.BookModels
{
    public class BookModel
    {
        [HiddenInput(DisplayValue = false)]
        public int ID { get; set; }
        public string Name { get; set; }
    }
}