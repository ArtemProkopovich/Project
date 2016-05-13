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
        void UpdateList(ServiceList list);
        IEnumerable<ServiceList> GetAllLists();
        ServiceList GetListById(int id);
        IEnumerable<ServiceBook> GetListBooks(ServiceList list);
        void AddListBook(ServiceList list, ServiceBook book);
        void RemoveListBook(ServiceList list, ServiceBook book);

        void AddBookTag(ServiceBook book, ServiceTag tag);
        void RemoveBookTag(ServiceBook book, ServiceTag tag);
        void AddTag(ServiceTag tag);
        void RemoveTag(ServiceTag tag);
        IEnumerable<ServiceTag> GetAllTags();
        ServiceTag GetTagById(int id);
        ServiceTag GetTagByName(string name);
        IEnumerable<ServiceBook> GetTagBooks(ServiceTag tag);

        void AddBookGenre(ServiceBook book, ServiceGenre genre);
        void RemoveBookGenre(ServiceBook book, ServiceGenre genre);
        void AddGenre(ServiceGenre genre);
        void RemoveGenre(ServiceGenre genre);
        IEnumerable<ServiceGenre> GetAllGenres();
        ServiceGenre GetGenreById(int id);
        ServiceGenre GetGenreByName(string name);
        IEnumerable<ServiceBook> GetGenreBooks(ServiceGenre genre);

    }
}
