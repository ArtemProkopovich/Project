using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Service.Interfacies.Entities;

namespace WebApplication.Models.ViewModels.ContentModels
{
    public class LikeButtonsModel
    {
        public int BookID { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public ServiceLike UserLike { get; set; }
    }
}