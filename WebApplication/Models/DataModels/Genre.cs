using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service.Interfacies;
using Service.Interfacies.Entities;
using WebApplication.Infrastructure.Mappers;
using WebApplication.Models.ViewModels.GenreModels;
using WebApplication.Models.ViewModels.TagModels;

namespace WebApplication.Models.DataModels
{
    public class Genre
    {
        private static readonly IServiceManager manager = DependencyResolver.Current.GetService<IServiceManager>();
        public static GenreModel GetGenreModel(ServiceGenre genre)
        {
            return genre.ToGenreModel();
        }

        public static GenreIndexModel GetGenreIndexModel()
        {
            GenreIndexModel model = new GenreIndexModel();
            model.Genres = manager.listService.GetAllGenres().OrderBy(e => e.Name).Select(GetGenreModel);
            return model;
        }
    }
}