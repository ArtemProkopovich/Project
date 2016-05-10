using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models.UserModels
{
    public class LoginModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Invalid login")]
        public string Login { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Invalid login.")]
        public string Password { get; set; }
    }
}