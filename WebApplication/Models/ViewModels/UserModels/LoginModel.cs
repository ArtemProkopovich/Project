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
        [Display(Name ="Login or email")]
        public string Login { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password can't be empty.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [Display(Name ="Remember me")]
        public bool Remember { get; set; }
    }
}