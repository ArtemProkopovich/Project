using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Service.Interfacies.Entities;
using WebApplication.Models;

namespace WebApplication.Infrastructure.Mappers
{
    public static class TagMapper
    {
        public static ServiceTag ToServiceTag(this TagModel tag)
        {
            return new ServiceTag
            {
                ID = tag.ID,
                Name = tag.Name
            };
        }

        public static TagModel ToTagModel(this ServiceTag tag)
        {
            return new TagModel
            {
                ID = tag.ID,
                Name = tag.Name
            };
        }
    }
}