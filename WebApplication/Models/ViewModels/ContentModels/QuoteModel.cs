using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models.ViewModels.ContentModels
{
    public class QuoteModel
    {
        public int ID { get; set; }
        public int CollectionBookID { get; set; }
        public string Text { get; set; }
    }
}