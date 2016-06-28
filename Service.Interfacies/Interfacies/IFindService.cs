using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Interfacies.Entities;

namespace Service.Interfacies
{
    public interface IFindService
    {
        IEnumerable<ServiceGenre> FindByGenre(string query);
        IEnumerable<ServiceList> FindByList(string query);
        IEnumerable<ServiceAuthor> FindByAuthor(string query);
        IEnumerable<ServiceBook> FindByBook(string query);
        IEnumerable<ServiceTag> FindByTag(string query);
        IEnumerable<string> FindByQuery(string query);
    }
}
