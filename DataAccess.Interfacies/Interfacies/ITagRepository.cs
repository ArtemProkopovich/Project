using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfacies.Entities;

namespace DataAccess.Interfacies
{
    public interface ITagRepository : IRepository<DalTag>
    {
        IEnumerable<DalBook> GetBooks(DalTag tag);
        DalTag GetByName(string name);
    }
}
