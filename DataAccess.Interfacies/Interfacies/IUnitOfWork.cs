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
        IAuthorRepository Authors { get; }
        IBookRepository Books { get; }
        ICollectionRepository Collections { get; }
        IGenreRepository Genres { get; }
        IListRepository Lists { get; }
        ITagRepository Tags { get; }
        IUserRepository Users { get; }
        void Save();
        Task SaveAsync();
    }
}
