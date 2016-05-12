using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Interfacies.Entities;

namespace Service.Interfacies.Interfacies
{
    public interface IListService
    {
        void AddList(ServiceList list);
        void RemoveList(ServiceList list);
        IEnumerable<ServiceList> GetAllLists();
        ServiceList GetListById(int id);

        void AddTag(ServiceTag tag);
        void RemoveTag(ServiceTag tag);
        IEnumerable<ServiceTag> GetAllTags();
        ServiceTag GetTagById(int id);
        ServiceTag GetTagByName(string name);

        void AddGenre(ServiceGenre genre);
        void RemoveGenre(ServiceGenre genre);
        IEnumerable<ServiceGenre> GetAllGenres();
        ServiceGenre GetGenreById(int id);
        ServiceGenre GetGenreByName(string name);

    }
}
