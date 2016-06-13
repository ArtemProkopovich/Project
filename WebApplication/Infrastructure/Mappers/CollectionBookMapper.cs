using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Service.Interfacies.Entities;
using WebApplication.Models.BookModels;
using WebApplication.Models.CollectionBookModels;
using WebApplication.Models.CollectionModels;

namespace WebApplication.Infrastructure.Mappers
{
    public static class CollectionBookMapper
    {
        public static CollectionBookModel ToCollectionBookModel(this ServiceCollectionBook clBook, BookShortModel book, CollectionModel cl)
        {
            return new CollectionBookModel()
            {
                ID = clBook.ID,
                collection = cl,
                IsRead = clBook.IsRead,
                book = book
            };
        }
    }
}