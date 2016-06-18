using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Service.Interfacies.Entities;
using WebApplication.Models.ViewModels.ContentModels;

namespace WebApplication.Infrastructure.Mappers
{
    public static class ScreeningMapper
    {
        public static ScreeningModel ToScreeningModel(this ServiceScreening scr)
        {
            return new ScreeningModel()
            {
                ID = scr.ID,
                Name = scr.Name,
                Link = scr.Link,
                Year = scr.Year,
                BookID = scr.BookID
            };
        }
    }
}