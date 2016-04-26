using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfacies.Entities;

namespace DataAccess.Interfacies
{
    public interface IListRepository : IRepository<DalList>
    {
        IEnumerable<DalBook> GetBooks(DalList list);
        void AddBook(DalList list, DalBook book);
        void AddBooks(DalList list, IEnumerable<DalBook> books);
        void DeleteBook(DalList list, DalBook book);
    }
}
