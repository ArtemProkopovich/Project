using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfacies.Entities;
using DataAccess.Interfacies.Interfacies;

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
        IRoleRepository Roles { get; }
        IUserRepository Users { get; }
        ICommentRepository Comments { get; }
        IContentRepository Contents { get; }
        IReviewRepository Reviews { get; }
        ILikeRepository Likes { get; }
        void Save();
        Task SaveAsync();
    }
}
