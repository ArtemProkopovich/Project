using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Service.Interfacies.Entities;
using WebApplication.Infrastructure.Mappers;
using WebApplication.Models.CollectionModels;

namespace WebApplication.Models.DataModels
{
    public class Collection
    {
        public static CollectionModel GetCollectionModel(ServiceCollection cl)
        {
            return cl.ToCollectionModel();
        }
    }
}