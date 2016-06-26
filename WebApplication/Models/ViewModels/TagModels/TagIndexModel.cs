using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models.ViewModels.TagModels
{
    public class TagIndexModel
    {
        public IEnumerable<TagModel> Tags { get; set; }
    }
}