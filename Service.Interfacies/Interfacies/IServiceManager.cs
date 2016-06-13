using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Interfacies;

namespace Service.Interfacies
{
    public interface IServiceManager
    {
        IAuthorService authorService { get;}
        IBookService bookService { get; }
        ICollectionService collectionService { get; }
        ICommentService commentService { get; }
        IFindService findService { get; }
        IListService listService { get; }
        IUserService userService { get; }
    }
}
