using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfacies;
using Service.Interfacies;

namespace ServiceLibrary.Service
{
    public class ServiceManager:IServiceManager
    {
        private readonly IUnitOfWork uof;
        public ServiceManager(IUnitOfWork uof)
        {
            this.uof = uof;
        }

        private  IAuthorService authorService;
        private  IBookService bookService;
        private  ICollectionService collectionService;
        private  ICommentService commentService;
        private  IFindService findService;
        private  IListService listService;
        private  IUserService userService;

        IAuthorService IServiceManager.authorService => authorService ?? (authorService = new AuthorService(uof));

        IBookService IServiceManager.bookService => bookService ?? (bookService = new BookService(uof));

        ICollectionService IServiceManager.collectionService
            => collectionService ?? (collectionService = new CollectionService(uof));

        ICommentService IServiceManager.commentService => commentService ?? (commentService = new CommentService(uof));

        IFindService IServiceManager.findService => findService ?? (findService = new FindService(uof));

        IListService IServiceManager.listService => listService ?? (listService = new ListService(uof));

        IUserService IServiceManager.userService => userService ?? (userService = new UserService(uof));
    }
}
