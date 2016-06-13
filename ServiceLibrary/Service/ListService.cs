using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfacies;
using Service.Interfacies;
using Service.Interfacies.Entities;
using ServiceLibrary.Mappers;

namespace ServiceLibrary.Service
{
    public class ListService : IListService
    {
        private readonly IUnitOfWork unit;

        public ListService(IUnitOfWork unit)
        {
            this.unit = unit;
        }

        public void AddBookGenre(ServiceBook book, ServiceGenre genre)
        {
            unit.Books.AddGenre(book.ToDalBook(), genre.ToDalGenre());
            unit.Save();
        }

        public void AddBookTag(ServiceBook book, ServiceTag tag)
        {
            unit.Books.AddTag(book.ToDalBook(), tag.ToDalTag());
            unit.Save();
        }

        public void AddGenre(ServiceGenre genre)
        {
            unit.Genres.Create(genre.ToDalGenre());
            unit.Save();
        }

        public void AddList(ServiceList list)
        {
            unit.Lists.Create(list.ToDalList());
            unit.Save();
        }

        public void AddListBook(ServiceList list, ServiceBook book)
        {
            unit.Lists.AddBook(list.ToDalList(), book.ToDalBook());
            unit.Save();
        }

        public void AddTag(ServiceTag tag)
        {
            unit.Tags.Create(tag.ToDalTag());
            unit.Save();
        }

        public IEnumerable<ServiceGenre> GetAllGenres()
        {
            return unit.Genres.GetAll().Select(e => e.ToServiceGenre());
        }

        public IEnumerable<ServiceList> GetAllLists()
        {
            return unit.Lists.GetAll().Select(e => e.ToServiceList());
        }

        public IEnumerable<ServiceTag> GetAllTags()
        {
            return unit.Tags.GetAll().Select(e => e.ToServiceTag());
        }

        public IEnumerable<ServiceBook> GetGenreBooks(ServiceGenre genre)
        {
            return unit.Genres.GetBooks(genre.ToDalGenre()).Select(e => e.ToServiceBook());
        }

        public ServiceGenre GetGenreById(int id)
        {
            return unit.Genres.GetById(id).ToServiceGenre();
        }

        public ServiceGenre GetGenreByName(string name)
        {
            return unit.Genres.GetByName(name)?.ToServiceGenre();
        }

        public IEnumerable<ServiceBook> GetListBooks(ServiceList list)
        {
            return unit.Lists.GetBooks(list.ToDalList()).Select(e => e.ToServiceBook());
        }

        public ServiceList GetListById(int id)
        {
            return unit.Lists.GetById(id).ToServiceList();
        }

        public IEnumerable<ServiceBook> GetTagBooks(ServiceTag tag)
        {
            return unit.Tags.GetBooks(tag.ToDalTag()).Select(e => e.ToServiceBook());
        }

        public ServiceTag GetTagById(int id)
        {
            return unit.Tags.GetById(id).ToServiceTag();
        }

        public ServiceTag GetTagByName(string name)
        {
            return unit.Tags.GetByName(name)?.ToServiceTag();
        }

        public void RemoveBookGenre(ServiceBook book, ServiceGenre genre)
        {
            unit.Books.DeleteGenre(book.ToDalBook(), genre.ToDalGenre());
            unit.Save();
        }

        public void RemoveBookTag(ServiceBook book, ServiceTag tag)
        {
            unit.Books.DeleteTag(book.ToDalBook(), tag.ToDalTag());
            unit.Save();
        }

        public void RemoveGenre(ServiceGenre genre)
        {
            unit.Genres.Delete(genre.ToDalGenre());
            unit.Save();
        }

        public void RemoveList(ServiceList list)
        {
            unit.Lists.Delete(list.ToDalList());
            unit.Save();
        }

        public void RemoveListBook(ServiceList list, ServiceBook book)
        {
            unit.Lists.DeleteBook(list.ToDalList(), book.ToDalBook());
            unit.Save();
        }

        public void RemoveTag(ServiceTag tag)
        {
            unit.Tags.Delete(tag.ToDalTag());
            unit.Save();
        }

        public void UpdateList(ServiceList list)
        {
            unit.Lists.Update(list.ToDalList());
            unit.Save();
        }
    }
}
