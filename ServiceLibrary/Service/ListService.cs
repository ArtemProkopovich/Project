using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfacies;
using Service.Interfacies.Entities;
using Service.Interfacies.Interfacies;
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

        public ServiceGenre GetGenreById(int id)
        {
            return unit.Genres.GetById(id).ToServiceGenre();
        }

        public ServiceGenre GetGenreByName(string name)
        {
            return unit.Genres.GetByName(name)?.ToServiceGenre();
        }

        public ServiceList GetListById(int id)
        {
            return unit.Lists.GetById(id).ToServiceList();
        }

        public ServiceTag GetTagById(int id)
        {
            return unit.Tags.GetById(id).ToServiceTag();
        }

        public ServiceTag GetTagByName(string name)
        {
            return unit.Tags.GetByName(name)?.ToServiceTag();
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

        public void RemoveTag(ServiceTag tag)
        {
            unit.Tags.Delete(tag.ToDalTag());
            unit.Save();
        }
    }
}
