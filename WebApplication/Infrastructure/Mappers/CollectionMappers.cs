using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Service.Interfacies.Entities;
using WebApplication.Models;
using WebApplication.Models.CollectionModels;

namespace WebApplication.Infrastructure.Mappers
{
    public static class CollectionMappers
    {
        public static ServiceCollection ToServiceCollection(this CollectionModel cl)
        {
            return new ServiceCollection
            {
                ID = cl.ID,
                Name = cl.Name,
                Description = cl.Description,
                UserID = cl.UserID
            };
        }

        public static CollectionModel ToCollectionModel(this ServiceCollection cl)
        {
            return new CollectionModel
            {
                ID = cl.ID,
                Name = cl.Name,
                Description = cl.Description,
                UserID = cl.UserID
            };
        }
    }
}