using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Service.Interfacies.Entities;

namespace WebApplication.Models.ViewModels.ListModels
{
    public class ListCoverModel
    {
        public ListModel List { get; set; }
        public IEnumerable<ServiceBook> Books { get; set; }
    }
}