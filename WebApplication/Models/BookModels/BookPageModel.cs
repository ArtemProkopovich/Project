using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service.Interfacies.Entities;
using WebApplication.Models.AuthorModels;

namespace WebApplication.Models.BookModels
{
    public class BookPageModel
    {
        [HiddenInput(DisplayValue =false)]
        public int ID { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; }
        public int AgeCategory { get; set; }
        public AuthorShortModel Author { get; set; }
        public IEnumerable<ServiceLike> Likes { get; set; }
        public string CoverPath { get; set; }
        public IEnumerable<ServiceGenre> Genres { get; set; }
        public IEnumerable<ServiceTag> Tags { get; set; }
        public IEnumerable<ServiceReview> Reviews { get; set; }
        public IEnumerable<ServiceComment> Comments { get; set; }
        public IEnumerable<ServiceScreening> Screening { get; set; }
        public IEnumerable<ServiceContent> Contents { get; set; }
        public IEnumerable<ServiceList> Lists { get; set; }
    }
}