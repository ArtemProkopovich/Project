using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Service.Interfacies.Entities;
using WebApplication.Models;
using WebApplication.Models.BookModels;

namespace WebApplication.Infrastructure.Mappers
{
    public static class ListMapper
    {
        public static ServiceList ToServiceList(this ListModel list)
        {
            return new ServiceList
            {
                ID = list.ID,
                Name = list.Name
            };
        }

        public static ListModel ToListModel(this ServiceList list)
        {
            return new ListModel
            {
                ID = list.ID,
                Name = list.Name
            };
        }

        public static ListBookListModel ToListBookListModel(this ServiceList list, IEnumerable<BookShortModel> books)
        {
            return new ListBookListModel
            {
                List = list.ToListModel(),
                Books = books
            };
        }
    }
}