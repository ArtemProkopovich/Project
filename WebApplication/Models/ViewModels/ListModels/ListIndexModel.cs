using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models.ViewModels.ListModels
{
    public class ListIndexModel
    {
        public IEnumerable<ListCoverModel> Lists { get; set; }
    }
}