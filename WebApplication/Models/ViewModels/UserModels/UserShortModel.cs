using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Models.UserModels
{
    public class UserShortModel
    {
        [HiddenInput(DisplayValue = false)]
        public int ID { get; set; }
        public string Name{ get; set; }
        public string Surname { get; set; }
        public string PhotoPath { get; set; }
    }
}