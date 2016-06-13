using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models.UserModels
{
    public class SignModel
    {
    
        [Required(AllowEmptyStrings = false, ErrorMessage = "Login can't be empty.")]
        public string Login { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Email can't be empty.")]
        [DataType(DataType.EmailAddress,ErrorMessage ="Email is not valid.")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password can't be empty.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Passwords don't match.")]
        public string ComfirmedPassword { get; set; }
    }
}