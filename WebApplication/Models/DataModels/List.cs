using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service.Interfacies;
using Service.Interfacies.Entities;
using WebApplication.Infrastructure.Mappers;
using WebApplication.Models.ViewModels.ListModels;

namespace WebApplication.Models.DataModels
{
    public class List
    {
        private static readonly IServiceManager manager = DependencyResolver.Current.GetService<IServiceManager>();

        public static ListShortModel GetListShortModel(int listID)
        {
            ListShortModel result = new ListShortModel();
            var list = manager.listService.GetListById(listID);
            var books = manager.listService.GetListBooks(list).ToList();
            var book =
                books.OrderBy(e => e.Name).SkipWhile(e => !manager.bookService.GetBookCovers(e).Any()).FirstOrDefault();
            result.List = list.ToListModel();
            result.bookID = book.ID;
            return result;
        }

        public static ListCoverModel GetListCoverModel(int listID)
        {
            var list = manager.listService.GetListById(listID);
            return GetListCoverModel(list);
        }

        public static ListCoverModel GetListCoverModel(ServiceList list)
        {
            ListCoverModel result = new ListCoverModel();
            var books = manager.listService.GetListBooks(list).ToList();
            List<ServiceBook> coverBooks = new List<ServiceBook>();
            for (int i = 0; i < books.Count || coverBooks.Count < 4; i++)
            {
                var covers = manager.bookService.GetBookCovers(books[i]);
                if (covers != null && covers.Count() != 0)
                {
                    coverBooks.Add(books[i]);
                }
            }
            books = books.Except(coverBooks, new BookEqualityComparer()).ToList();
            if (coverBooks.Count < 4)
            {
                coverBooks.AddRange(books.Take(4 - coverBooks.Count));
            }
            result.List = list.ToListModel();
            result.Books = coverBooks;
            return result;
        }

        private class BookEqualityComparer : IEqualityComparer<ServiceBook>
        {
            public bool Equals(ServiceBook x, ServiceBook y)
            {
                return x.ID == y.ID;
            }

            public int GetHashCode(ServiceBook obj)
            {
                return obj.ID;
            }
        }

        public static ListIndexModel GetListIndexModel()
        {
            ListIndexModel model = new ListIndexModel();
            model.Lists = manager.listService.GetAllLists().Select(GetListCoverModel);
            return model;
        }
    }
}