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
    public class FindService : IFindService
    {
        private readonly IUnitOfWork unit;
        public FindService(IUnitOfWork unit)
        {
            this.unit = unit;
        }

        public IEnumerable<ServiceBook> FindAll(Func<ServiceBook, bool> func)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ServiceBook> FindByAuthor(ServiceAuthor author)
        {
            return unit.Authors.GetBooks(author.ToDalAuthor()).Select(e=>e.ToServiceBook());
        }

        public IEnumerable<ServiceBook> FindByGenre(ServiceGenre genre)
        {
            return unit.Genres.GetBooks(genre.ToDalGenre()).Select(e => e.ToServiceBook());
        }

        public IEnumerable<ServiceBook> FindByList(ServiceList list)
        {
            return unit.Lists.GetBooks(list.ToDalList()).Select(e => e.ToServiceBook());
        }

        public IEnumerable<ServiceBook> FindByQuery(string query)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ServiceBook> FindByTag(ServiceTag tag)
        {
            return unit.Tags.GetBooks(tag.ToDalTag()).Select(e=>e.ToServiceBook());
        }

        public IEnumerable<ServiceAuthor> GetAllAuthors()
        {
            return unit.Authors.GetAll().Select(e => e.ToServiceAuthor());
        }

        public IEnumerable<ServiceBook> GetAllBooks()
        {
            return unit.Books.GetAll().Select(e => e.ToServiceBook());
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
    }
}
