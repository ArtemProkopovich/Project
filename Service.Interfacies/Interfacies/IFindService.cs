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
        IEnumerable<ServiceList> GetAll();
        IEnumerable<ServiceList> FindAll(Func<ServiceList, bool> func);
        IEnumerable<ServiceBook> FindByGenre(ServiceGenre genre);
        IEnumerable<ServiceBook> FindByList(ServiceList list);
        IEnumerable<ServiceBook> FindByAuthor(ServiceAuthor author);
        IEnumerable<ServiceBook> FindByQuery(string query);
    }
}
