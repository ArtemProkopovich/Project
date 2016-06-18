using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Models.AuthorModels
{
    public class AuthorEditModel
    {
        [HiddenInput(DisplayValue =false)]
        public int ID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Name can't be empty")]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Birth date")]
        public DateTime BirthDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Death date")]
        public DateTime DeathDate { get; set; }
        public string PhotoPath { get; set; }

        [Display(Name = "Upload new photo")]
        public HttpPostedFileBase NewPhoto { get; set; }

        public string Biography { get; set; }
    }
}