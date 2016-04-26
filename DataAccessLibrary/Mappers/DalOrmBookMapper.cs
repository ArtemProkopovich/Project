using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfacies.Entities;
using ORMLibrary;

namespace DataAccessLibrary.Mappers
{
    public static class DalOrmBookMapper
    {
        public static Books ToOrmBook(this DalBook book)
        {
            return new Books()
            {
                BookID = book.ID,
                Age_Caegory = book.AgeCategory,
                First_Publication = book.FirstPublication,
                Name = book.Name
            };
        }

        public static DalBook ToDalBook(this Books book)
        {
            return new DalBook
            {
                ID = book.BookID,
                FirstPublication = book.First_Publication,
                Name = book.Name,
                AgeCategory = book.Age_Caegory ?? 0
            };
        }
    }
}
