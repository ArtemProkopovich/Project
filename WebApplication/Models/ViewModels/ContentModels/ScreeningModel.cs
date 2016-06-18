using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models.ViewModels.ContentModels
{
    public class ScreeningModel
    {
        public int ID { get; set; }
        public int BookID { get; set; }
        public string Name { get; set; }
        public DateTime Year { get; set; }
        public string Link { get; set; }
    }
}