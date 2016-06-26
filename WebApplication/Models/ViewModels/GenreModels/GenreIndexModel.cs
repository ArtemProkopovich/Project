using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models.ViewModels.GenreModels
{
    public class GenreIndexModel
    {
        public IEnumerable<GenreModel> Genres { get; set; }
    }
}