using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service.Interfacies.Entities;
using WebApplication.Models.AuthorModels;
using WebApplication.Models.CollectionModels;
using WebApplication.Models.ContentModels;
using WebApplication.Models.ViewModels.CollectionBookModels;
using WebApplication.Models.ViewModels.ContentModels;

namespace WebApplication.Models.BookModels
{
    public class BookPageModel
    {
        [HiddenInput(DisplayValue =false)]
        public int ID { get; set; }
        [Display(Name = "Title")]
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime? PublishDate { get; set; }
        public int AgeCategory { get; set; }
        public IEnumerable<AuthorShortModel> Authors { get; set; }
        public LikeButtonsModel Likes { get; set; }
        public BookInCollectionsModel Collections { get; set; }
        public IEnumerable<CoverModel> Covers { get; set; }
        public IEnumerable<GenreModel> Genres { get; set; }
        public IEnumerable<TagModel> Tags { get; set; }
        public IEnumerable<ReviewModel> Reviews { get; set; }
        public IEnumerable<CommentModel> Comments { get; set; }
        public IEnumerable<ScreeningModel> Screening { get; set; }
        public IEnumerable<ContentModel> Contents { get; set; }
        public IEnumerable<ListModel> Lists { get; set; }
    }
}