using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfacies.Entities;
using ORMLibrary;

namespace DataAccessLibrary.Mappers
{
    public static class DalOrmCollectionBookMapper
    {
        public static Collection_Book ToOrmCollectionBook(this DalCollectionBook cb)
        {
            return new Collection_Book
            {
                Collection_BookID = cb.ID,
                CollectionID = cb.CollectionID,
                BookID = cb.BookID,
                IsRead = cb.IsRead
            };
        }

        public static DalCollectionBook ToDalCollectionBook(this Collection_Book cb)
        {
            return new DalCollectionBook
            {
                ID = cb.Collection_BookID,
                BookID = cb.BookID,
                CollectionID = cb.CollectionID,
                IsRead = cb.IsRead
            };
        }
    }
}
