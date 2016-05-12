using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfacies.Entities;

namespace DataAccess.Interfacies
{
    public interface IGenreRepository : IRepository<DalGenre>
    {
        IEnumerable<DalBook> GetBooks(DalGenre genre);
        DalGenre GetByName(string name);
    }
}
