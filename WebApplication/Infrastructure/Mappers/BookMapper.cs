using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Service.Interfacies.Entities;
using WebApplication.Models.AuthorModels;
using WebApplication.Models.BookModels;
using WebApplication.Models.DataModels;
using WebApplication.Models.ViewModels.BookModels;
using WebApplication.Models.ViewModels.ContentModels;

namespace WebApplication.Infrastructure.Mappers
{
    public static class BookMapper
    {

        public static BookShortModel ToBookShortModel(this ServiceBook book)
        {
            return new BookShortModel()
            {
                ID = book.ID,
                Name = book.Name,
                Cover = ""
            };
        }

        public static BookPageModel  ServiceBookToModelBook(this ServiceFullBook sfb)
        {
            BookPageModel model = new BookPageModel
            {
                ID = sfb.BookData.ID,
                Name = sfb.BookData.Name,
                PublishDate = sfb.BookData.FirstPublication,
                AgeCategory = sfb.BookData.AgeCategory,
            };
            return model;
        }

        public static BookShortModel ToBookShortModel(this ServiceFullBook sfb, int userID)
        {
            var author = sfb.Authors.FirstOrDefault();
            return new BookShortModel()
            {
                ID = sfb.BookData.ID,
                Name = sfb.BookData.Name,             
                Likes = Like.GetLikeButtonsModel(sfb.BookData.ID, userID),
                Cover = sfb.Covers.FirstOrDefault()?.ImagePath,
                Author = new AuthorShortModel() {ID = author?.ID ?? 0, Name = author?.Name, PhotoPath = author?.Photo}
            };
        }

        public static ServiceBook CreateModelToServiceBook(this BookCreateModel bkm)
        {
            ServiceBook sb = new ServiceBook()
            {
                AgeCategory = bkm.AgeCategory,
                FirstPublication = bkm.PublishDate,
                Name = bkm.Name
            };
            return sb;
        }

        public static BookEditModel ToEditModel(this ServiceBook book)
        {
            return new BookEditModel()
            {
                ID = book.ID,
                AgeCategory = book.AgeCategory,
                PublishDate = book.FirstPublication,
                Name = book.Name,

            };
        }

        public static ServiceBook ToServiceBook(this BookEditModel model)
        {
            return new ServiceBook()
            {
                ID = model.ID,
                AgeCategory = model.AgeCategory,
                FirstPublication = model.PublishDate,
                Name = model.Name
            };
        }
    }
}