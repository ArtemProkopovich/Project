using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service.Interfacies;
using Service.Interfacies.Entities;
using WebApplication.Infrastructure.Mappers;
using WebApplication.Models.CollectionBookModels;
using WebApplication.Models.CollectionModels;

namespace WebApplication.Models.DataModels
{
    public class Collection
    {
        public static CollectionModel GetCollectionModel(ServiceCollection cl)
        {
            return cl.ToCollectionModel();
        }

        private static readonly IServiceManager manager = DependencyResolver.Current.GetService<IServiceManager>();

        public static CollectionListModel GetCollectionListModel(int userID)
        {
            var user = manager.userService.GetUserById(userID);
            var profile = User.Get_UserProfileModel(user.ID);
            var userCollections = manager.collectionService.GetUserCollections(user).OrderBy(e => e.Name);
            List<CollectionBookListModel> collectionsBooks = new List<CollectionBookListModel>();
            foreach (var cl in userCollections)
            {
                CollectionBookListModel collectionBooksModel = new CollectionBookListModel();
                collectionBooksModel.collection = cl.ToCollectionModel();
                List<CollectionBookModel> books = new List<CollectionBookModel>();
                var collcetionBooks = manager.collectionService.GetCollectionBooks(cl);
                foreach (var book in collcetionBooks)
                {
                    var shortBook = Book.GetBookShortModel(book.BookID, userID);
                    books.Add(book.ToCollectionBookModel(shortBook, collectionBooksModel.collection));
                }
                collectionBooksModel.books = books;
                collectionsBooks.Add(collectionBooksModel);
            }
            return new CollectionListModel(profile, collectionsBooks);

        }
    }
}