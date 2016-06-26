using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfacies.Entities;
using ORMLibrary;

namespace DataAccessLibrary.Mappers
{
    public static class DalOrmGenreMapper
    {
        public static Genres ToOrmGenre(this DalGenre genre)
        {
            return new Genres
            {
                GenreID = genre.ID,
                Name = genre.Name,
                Parent_GenreID = genre.ParentGenreID,
            };
        }

        public static DalGenre ToDalGenre(this Genres genre)
        {
            return new DalGenre
            {
                ID = genre.GenreID,
                Name = genre.Name,
                ParentGenreID = genre.Parent_GenreID
            };
        }
    }
}
