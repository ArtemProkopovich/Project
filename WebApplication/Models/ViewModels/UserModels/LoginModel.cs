using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models.UserModels
{
    public class LoginModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Login can't be empty")]
        public string Login { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password can't be empty.")]
        public string Password { get; set; }
    }
}