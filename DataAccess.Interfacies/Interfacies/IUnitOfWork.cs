using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfacies.Entities;

namespace DataAccess.Interfacies
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<DalAuthor> Authors { get; }
        IRepository<DalBook> Books { get; }
        IRepository<DalUser> Users { get; }
        IRepository<DalList> Lists { get; }
        IRepository<DalTag> Tags { get; }
        IRepository<DalGenre> Genres { get; }
        IRepository<DalCollection> Collections { get; }
        void Save();
        Task SaveAsync();
    }
}
