using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfacies;
using DataAccess.Interfacies.Entities;
using ORMLibrary;

namespace DataAccessLibrary.Repository
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly DbContext context;
        private bool disposed = false;
        private AuthorRepository authorRepository;
        private BookRepository bookRepository;
        private CollectionRepository collectionRepository;
        private UserRepository userRepository;
        private ListRepository listRepository;
        private TagRepository tagRepository;
        private GenreRepository genreRepository;
        public EFUnitOfWork(DbContext context)
        {
            this.context = context;
        }
        public IRepository<DalAuthor> Authors => authorRepository ?? (authorRepository = new AuthorRepository(context));

        public IRepository<DalBook> Books => bookRepository ?? (bookRepository = new BookRepository(context));

        public IRepository<DalCollection> Collections => collectionRepository ?? (collectionRepository = new CollectionRepository(context));

        public IRepository<DalGenre> Genres => genreRepository ?? (genreRepository = new GenreRepository(context));

        public IRepository<DalList> Lists => listRepository ?? (listRepository = new ListRepository(context));

        public IRepository<DalTag> Tags => tagRepository ?? (tagRepository = new TagRepository(context));

        public IRepository<DalUser> Users => userRepository ?? (userRepository = new UserRepository(context));

        ~EFUnitOfWork()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!disposed)
            {
                context.Dispose();
                GC.SuppressFinalize(this);
            }
            else
                throw new ObjectDisposedException(nameof(EFUnitOfWork), "Object was disposed yet.");
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
