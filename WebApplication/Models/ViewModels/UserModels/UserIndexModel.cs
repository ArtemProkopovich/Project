using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Models.UserModels;

namespace WebApplication.Models.ViewModels.UserModels
{
    public class UserIndexModel
    {
        public UserProfileModel Profile { get; set; }
        public int ReviewCount { get; set; }
        public int ContentCount { get; set; }
        public int CommentCount { get; set; }
        public int CollectionCount { get; set; }
        public int BookCount { get; set; }
    }
}