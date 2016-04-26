using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfacies.Entities;
using ORMLibrary;

namespace DataAccessLibrary.Mappers
{
    public static class DalOrmScreeningMapper
    {
        public static Screenings ToOrmScreening(this DalScreening screening)
        {
            return new Screenings
            {
                ScreeningID = screening.ID,
                BookID = screening.BookID,
                Link = screening.Link,
                Film_Name = screening.Name,
                Year = screening.Year
            };
        }

        public static DalScreening ToDalScreening(this Screenings screening)
        {
            return new DalScreening
            {
                ID = screening.ScreeningID,
                BookID = screening.BookID,
                Link = screening.Link,
                Name = screening.Film_Name,
                Year = screening.Year
            };
        }
    }
}
