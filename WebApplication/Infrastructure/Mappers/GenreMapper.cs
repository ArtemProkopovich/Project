using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Service.Interfacies.Entities;
using WebApplication.Models;
using WebApplication.Models.BookModels;

namespace WebApplication.Infrastructure.Mappers
{
    public static class GenreMapper
    {
        public static ServiceGenre ToServiceGenre(this GenreModel genre)
        {
            return new ServiceGenre
            {
                ID = genre.ID,
                Name = genre.Name,
                ParentGenreID = genre.ParentGenreID,
            };
        }

        public static GenreModel ToGenreModel(this ServiceGenre genre)
        {
            return new GenreModel
            {
                ID = genre.ID,
                Name = genre.Name,
                ParentGenreID = genre.ParentGenreID,
            };
        }

        public static GenreBookListModel ToGenreBookListModel(this ServiceGenre genre, IEnumerable<BookShortModel> books)
        {
            return new GenreBookListModel
            {
                Genre = genre.ToGenreModel(),
                Books = books
            };
        }
    }
}