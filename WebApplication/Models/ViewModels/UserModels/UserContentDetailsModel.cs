using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Models.ContentModels;
using WebApplication.Models.Shared;

namespace WebApplication.Models.ViewModels.UserModels
{
    public class UserContentDetailsModel : _UserProfileModel
    {
        public IEnumerable<CommentModel> Comments { get; set; }
        public IEnumerable<ContentModel> Contents { get; set; }
        public IEnumerable<ReviewModel> Reviews { get; set; }
    }
}