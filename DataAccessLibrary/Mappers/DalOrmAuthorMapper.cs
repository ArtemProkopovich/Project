using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfacies;
using DataAccess.Interfacies.Entities;
using ORMLibrary;

namespace DataAccessLibrary.Mappers
{
    public static class DalOrmAuthorMapper
    {
        public static DalAuthor ToDalAuthor(this Authors author)
        {
            return new DalAuthor()
            {
                ID = author.AuthorID,
                Name = author.Name,
                BirthDate = author.Birth_Date,
                DeathDate = author.Death_Date,
                Biography = author.Biography,
                Photo = author.Photo_Path
                
            };
        }

        public static Authors ToOrmAuthor(this DalAuthor author)
        {
            return new Authors()
            {
                AuthorID = author.ID,
                Name = author.Name,
                Birth_Date = author.BirthDate,
                Death_Date = author.DeathDate,
                Biography = author.Biography,
                Photo_Path = author.Photo
            };
        }
    }
}
