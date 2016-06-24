using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Models.BookModels;
using WebApplication.Models.ContentModels;
using WebApplication.Models.UserModels;

namespace WebApplication.Models.ContentModels
{

    public enum ReviewType
    {
        Negative, Neutral, Positive
    }
    public class ReviewModel
    {
        public int ID { get; set; }
        public UserShortModel User { get; set; }
        public BookShortModel Book { get; set; }
        public string Header { get; set; }
        public string Text { get; set; }
        public DateTime PublishTime { get; set; }
        public ReviewType Type { get; set; }
    }
}