using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfacies;
using DataAccessLibrary.Repository;
using Ninject;
using Ninject.Web.Common;
using ORMLibrary;
using Service.Interfacies;
using ServiceLibrary.Service;

namespace DependencyResolverLibrary
{
    public static class ResolverConfig
    {
        public static void ConfigurateResolverWeb(this IKernel kernel)
        {
            Configure(kernel, true);
        }

        public static void ConfigurateResolverConsole(this IKernel kernel)
        {
            Configure(kernel, false);
        }

        private static void Configure(IKernel kernel, bool isWeb)
        {
            if (isWeb)
            {
                kernel.Bind<IUnitOfWork>().To<EFUnitOfWork>().InRequestScope();
                kernel.Bind<ProjectDataEntities>().To<ProjectDataEntities>().InRequestScope();
            }
            else
            {
                kernel.Bind<IUnitOfWork>().To<EFUnitOfWork>().InSingletonScope();
                kernel.Bind<ProjectDataEntities>().To<ProjectDataEntities>().InSingletonScope();
            }
            #region services
            kernel.Bind<IAuthorService>().To<AuthorService>();
            kernel.Bind<IBookService>().To<BookService>();
            kernel.Bind<ICollectionService>().To<CollectionService>();
            kernel.Bind<ICommentService>().To<CommentService>();
            kernel.Bind<IFindService>().To<FindService>();
            kernel.Bind<IUserService>().To<UserService>();
            #endregion
            #region repositories 
            kernel.Bind<IUserRepository>().To<UserRepository>();
            kernel.Bind<IAuthorRepository>().To<AuthorRepository>();
            kernel.Bind<IBookRepository>().To<BookRepository>();
            kernel.Bind<ICollectionRepository>().To<CollectionRepository>();
            kernel.Bind<ITagRepository>().To<TagRepository>();
            kernel.Bind<IGenreRepository>().To<GenreRepository>();
            kernel.Bind<IListRepository>().To<ListRepository>();
            #endregion
        }
    }
}
