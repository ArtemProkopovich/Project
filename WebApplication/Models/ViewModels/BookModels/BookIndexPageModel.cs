﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Models.AuthorModels;
using WebApplication.Models.ViewModels.BookModels;
using WebApplication.Models.ViewModels.ListModels;

namespace WebApplication.Models.BookModels
{
    public class BookIndexPageModel
    {
        public IEnumerable<BookModel> Books { get; set; }
        public IEnumerable<AuthorShortModel> Authors { get; set; }
        public IEnumerable<GenreFirstModel> Genres { get; set; }
        public IEnumerable<ListShortModel> Lists { get; set; }
    }
}