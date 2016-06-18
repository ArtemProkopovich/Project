using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace WebApplication.Models.AuthorModels
{
    public class AuthorShortModel
    {
        [HiddenInput(DisplayValue =false)]
        public int ID { get; set; }
        public string Name { get; set; }
        public string PhotoPath { get; set; }
    }
}