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

        public IEnumerable<ServiceAuthor> FindByAuthor(string query)
        {
            return unit.Authors.FindAll(e => e.Name.Contains(query)).Select(e => e.ToServiceAuthor());
        }

        public IEnumerable<ServiceBook> FindByBook(string query)
        {
            return unit.Books.FindAll(e => e.Name.Contains(query)).Select(e => e.ToServiceBook());
        }

        public IEnumerable<ServiceGenre> FindByGenre(string query)
        {
            return unit.Genres.FindAll(e => e.Name.Contains(query)).Select(e => e.ToServiceGenre());
        }

        public IEnumerable<ServiceList> FindByList(string query)
        {
            return unit.Lists.FindAll(e => e.Name.Contains(query)).Select(e => e.ToServiceList());
        }

        public IEnumerable<string> FindByQuery(string query)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ServiceTag> FindByTag(string query)
        {
            return unit.Tags.FindAll(e => e.Name.Contains(query)).Select(e => e.ToServiceTag());
        }
    }
}
