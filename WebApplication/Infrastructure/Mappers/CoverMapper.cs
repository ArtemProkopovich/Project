using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Service.Interfacies.Entities;
using WebApplication.Models.ViewModels.ContentModels;

namespace WebApplication.Infrastructure.Mappers
{
    public static class CoverMapper
    {
        public static CoverModel ToCoverModel(this ServiceCover cover)
        {
            return new CoverModel()
            {
                BookID = cover.BookID,
                Path = cover.ImagePath,
            };
        }
    }
}