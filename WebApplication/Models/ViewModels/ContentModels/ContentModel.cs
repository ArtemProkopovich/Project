﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Models.UserModels;

namespace WebApplication.Models.ContentModels
{
    public class ContentModel
    {
        public int ID { get; set; }
        public int BookID { get; set; }
        public UserShortModel User { get; set; }
        public string Text { get; set; }
    }
}