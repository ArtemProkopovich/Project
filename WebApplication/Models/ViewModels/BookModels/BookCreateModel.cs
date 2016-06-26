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
        public string Author { get; set; }
        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; }
        public int AgeCategory { get; set; }
        public HttpPostedFileBase File { get; set; }
        public HttpPostedFileBase Cover { get; set; }
        [AllowHtml]
        public string Content { get; set; }
        public string Genre { get; set; }
        public string Tag { get; set; }
        [DataType(DataType.Url)]
        public string Screening { get; set; }
    }
}