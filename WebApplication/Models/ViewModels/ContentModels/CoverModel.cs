using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models.ViewModels.ContentModels
{
    public class CoverModel
    {
        public int ID { get; set; }
        public int BookID { get; set; }
        public string Path { get; set; }
    }
}