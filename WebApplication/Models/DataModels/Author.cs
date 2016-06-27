using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service.Interfacies;
using WebApplication.Infrastructure.Mappers;
using WebApplication.Models.ViewModels.AuthorModels;

namespace WebApplication.Models.DataModels
{
    public class Author
    {
        private static readonly IServiceManager manager = DependencyResolver.Current.GetService<IServiceManager>();

        public static AuthorIndexModel GetAuthorIndexModel(int booksOnPage, int currentPage)
        {
            AuthorIndexModel model = new AuthorIndexModel();
            model.bookOnPageCount = booksOnPage;
            model.currentPage = currentPage;
            int allBooksCount = manager.authorService.GetAuthorsCount();
            int maxPage = allBooksCount%booksOnPage == 0 ? allBooksCount/booksOnPage : allBooksCount/booksOnPage + 1;
            maxPage = maxPage == 0 ? 1 : maxPage;
            currentPage = currentPage < maxPage ? currentPage < 1 ? 1 : currentPage : maxPage;
            model.bookOnPageCount = booksOnPage;
            model.currentPage = currentPage;
            model.pageCount = maxPage;
            model.Authors =
                manager.authorService.OrderTake((currentPage - 1)*booksOnPage, booksOnPage)
                    .Select(e => e.ToAuthorShortModel());
            return model;
        }
    }
}