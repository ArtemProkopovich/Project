using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models.BookModels;

namespace WebApplication.Models.AuthorModels
{
    public class AuthorFullModel
    {
        [HiddenInput(DisplayValue = false)]
        public int ID { get; set; }
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Birth date")]
        public DateTime BirthDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Death date")]
        public DateTime DeathDate { get; set; }
        public string PhothPath { get; set; }
        public string Biography { get; set; }

        public IEnumerable<BookShortModel> Books { get; set; }
    }
}