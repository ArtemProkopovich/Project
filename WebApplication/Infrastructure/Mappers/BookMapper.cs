using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Service.Interfacies.Entities;
using WebApplication.Models.AuthorModels;
using WebApplication.Models.BookModels;

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
                AgeCategory = sfb.BookData.AgeCategory,
                Author = sfb.Authors.FirstOrDefault()?.ToAuthorShortModel(),
                Comments = sfb.Comments,
                Contents = sfb.Contents,
                CoverPath = sfb.Covers.FirstOrDefault()?.ImagePath ?? ""
            };
            model.Comments = sfb.Comments;
            model.Genres = sfb.Genres;
            model.ID = sfb.BookData.ID;
            model.Likes = sfb.Likes;
            model.Lists = sfb.Lists;
            model.Name = sfb.BookData.Name;
            model.PublishDate = sfb.BookData.FirstPublication ?? new DateTime();
            model.Reviews = sfb.Review;
            model.Screening = sfb.Screeninigs;
            model.Tags = sfb.Tags;
            return model;
        }

        public static BookShortModel ToBookShortModel(this ServiceFullBook sfb)
        {
            var author = sfb.Authors.FirstOrDefault();
            return new BookShortModel()
            {
                ID = sfb.BookData.ID,
                Name = sfb.BookData.Name,
                Likes = sfb.Likes.Count(e => e.Like),
                Dislikes = sfb.Likes.Count(e => !e.Like),
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