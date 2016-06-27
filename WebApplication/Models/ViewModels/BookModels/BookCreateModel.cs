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
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name can't be empty.")]
        [Display(Name = "Title")]
        public string Name { get; set; }
        public int[] Authors { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date of publication")]
        public DateTime? PublishDate { get; set; }

        [Display(Name = "Age category")]
        public int AgeCategory { get; set; }

        public HttpPostedFileBase[] Files { get; set; }
        public HttpPostedFileBase[] Covers { get; set; }

        [AllowHtml]
        [Display(Name = "Summary")]
        public string Content { get; set; }

        public int[] Genres { get; set; }
        public int[] Tags { get; set; }

        [DataType(DataType.Url)]
        public string Screening { get; set; }

        public IEnumerable<ServiceGenre> GenreList { get; set; }
        public IEnumerable<ServiceTag> TagList { get; set; }
        public IEnumerable<ServiceAuthor> AuthorList { get; set; }
    }
}