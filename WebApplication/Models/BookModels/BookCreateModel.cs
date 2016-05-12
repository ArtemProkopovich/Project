using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service.Interfacies.Entities;

namespace WebApplication.Models.BookModels
{
    public class BookCreateModel
    {
        [Required(AllowEmptyStrings =false, ErrorMessage = "Name can't be empty.")]
        public string Name { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Author can't be empty.")]
        public string Author { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Date can't be empty.")]
        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage ="Age can't be empty.")]
        public int AgeCategory { get; set; }
        public HttpPostedFileBase File { get; set; }
        public HttpPostedFileBase Cover { get; set; }
        [Required(AllowEmptyStrings = true)]
        public string Content { get; set; }
        public string Genre { get; set; }
        public string Tag { get; set; }
        [Required(AllowEmptyStrings = true)]
        public string Screening { get; set; }
    }
}