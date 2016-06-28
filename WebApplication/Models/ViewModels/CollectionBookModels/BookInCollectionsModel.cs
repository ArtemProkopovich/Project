using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Models.CollectionModels;

namespace WebApplication.Models.ViewModels.CollectionBookModels
{
    public class BookInCollectionsModel
    {
        public int BookID { get; set; }
        public IEnumerable<CollectionModel> CollectionsWithBook { get; set; }
        public IEnumerable<CollectionModel> CollectionsWithoutBook { get; set; }
    }
}