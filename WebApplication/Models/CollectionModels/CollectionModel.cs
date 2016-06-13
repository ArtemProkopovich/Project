using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Models.CollectionModels
{
    public class CollectionModel
    {
        [HiddenInput(DisplayValue = false)]
        public int ID { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int UserID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Name can't be empty.")]
        public string Name { get; set; } = "";

        public string Description { get; set; } = "";
    }
}