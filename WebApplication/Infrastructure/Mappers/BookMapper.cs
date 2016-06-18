using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Service.Interfacies.Entities;
using WebApplication.Models.AuthorModels;
using WebApplication.Models.BookModels;
using WebApplication.Models.DataModels;

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
                PublishDate = sfb.BookData.FirstPublication ?? new DateTime(),
                AgeCategory = sfb.BookData.AgeCategory,
            };
            return model;
        }

        public static BookShortModel ToBookShortModel(this ServiceFullBook sfb)
        {
            var author = sfb.Authors.FirstOrDefault();
            return new BookShortModel()
            {
                ID = sfb.BookData.ID,
                Name = sfb.BookData.Name,
                Likes = sfb.Likes?.Count(e => e.Like) ?? 0,
                Dislikes = sfb.Likes?.Count(e => !e.Like) ?? 0,
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
    }
}