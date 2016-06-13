using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Models.UserModels
{
    public class UserProfileModel
    {
        [HiddenInput(DisplayValue = false)]
        public int ID { get; set; }

        [Required(ErrorMessage = "Name can't be empty.")]
        public string Name { get; set; } = "";

        [Required(ErrorMessage = "Surname can't be empty.")]
        public string Surname { get; set; } = "";

        [Display(Name = "Birth date")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [Display(Name = "Gender")]
        public bool? Male { get; set; }
        public int Level { get; set; }
        public int Points { get; set; }
        public string PhotoPath { get; set; }

        [Display(Name = "Upload new photo")]
        [DataType(DataType.Upload)]
        public HttpPostedFileBase NewPhoto { get; set; }
    }
}