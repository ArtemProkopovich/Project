using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models.BookModels
{
    public class BookCreateModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Author { get; set; }
    }
}