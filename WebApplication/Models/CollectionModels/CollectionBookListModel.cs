using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Models.CollectionBookModels;

namespace WebApplication.Models.CollectionModels
{
    public class CollectionBookListModel
    {
        public CollectionModel collection;
        public IEnumerable<CollectionBookModel> books;
    }
}