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
        IEnumerable<ServiceList> GetAllLists();
        IEnumerable<ServiceGenre> GetAllGenres();
        IEnumerable<ServiceTag> GetAllTags();
        IEnumerable<ServiceAuthor> GetAllAuthors();
        IEnumerable<ServiceBook> GetAllBooks();
        IEnumerable<ServiceBook> FindAll(Func<ServiceBook, bool> func);
        IEnumerable<ServiceBook> FindByGenre(ServiceGenre genre);
        IEnumerable<ServiceBook> FindByList(ServiceList list);
        IEnumerable<ServiceBook> FindByAuthor(ServiceAuthor author);
        IEnumerable<ServiceBook> FindByTag(ServiceTag tag);
        IEnumerable<ServiceBook> FindByQuery(string query);
    }
}
