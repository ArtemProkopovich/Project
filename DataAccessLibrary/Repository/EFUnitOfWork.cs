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
        private readonly ProjectDataEntities context;
        private bool disposed = false;
        private AuthorRepository authorRepository;
        private BookRepository bookRepository;
        private CollectionRepository collectionRepository;
        private UserRepository userRepository;
        private ListRepository listRepository;
        private TagRepository tagRepository;
        private GenreRepository genreRepository;

        public IAuthorRepository Authors
        {
            get
            {
                if (authorRepository == null)
                    authorRepository = new AuthorRepository(context);
                return authorRepository;
            }
        }

        public IBookRepository Books
        {
            get
            {
                if (bookRepository == null)
                    bookRepository = new BookRepository(context);
                return bookRepository;
            }
        }

        public ICollectionRepository Collections
        {
            get
            {
                if (collectionRepository == null)
                    collectionRepository = new CollectionRepository(context);
                return collectionRepository;
            }
        }

        public IGenreRepository Genres
        {
            get
            {
                if (genreRepository == null)
                    genreRepository = new GenreRepository(context);
                return genreRepository;
            }
        }

        public IListRepository Lists
        {
            get
            {
                if (listRepository == null)
                    listRepository = new ListRepository(context);
                return listRepository;
            }
        }

        public ITagRepository Tags
        {
            get
            {
                if (tagRepository == null)
                    tagRepository = new TagRepository(context);
                return tagRepository;
            }
        }

        public IUserRepository Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(context);
                return userRepository;
            }
        }

        public EFUnitOfWork(ProjectDataEntities context)
        {
            this.context = context;
        }

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
