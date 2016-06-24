using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfacies;
using DataAccess.Interfacies.Entities;
using ORMLibrary;
using DataAccessLibrary.Mappers;

namespace DataAccessLibrary.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly DatabaseContext context;
        public BookRepository(DatabaseContext context)
        {
            this.context = context;
        }

        public void AddAuthor(DalBook book, DalAuthor author)
        {
            var dbBook = context.Books.FirstOrDefault(e => e.BookID == book.ID);
            var dbAuthor = context.Authors.FirstOrDefault(e => e.AuthorID == author.ID);
            if (dbBook != null && dbAuthor!=null)
            {
                dbBook.Authors.Add(dbAuthor);
            }
        }

        public void AddCover(DalBook book, DalCover cover)
        {
            var dbBook = context.Books.FirstOrDefault(e => e.BookID == book.ID);
            if (dbBook != null)
            {
                dbBook.Covers.Add(cover.ToOrmCover());
            }
        }

        public void AddFile(DalBook book, DalFile file)
        {
            var dbBook = context.Books.FirstOrDefault(e => e.BookID == book.ID);
            if (dbBook != null)
            {
                dbBook.Files.Add(file.ToOrmFile());
            }
        }

        public void AddGenre(DalBook book, DalGenre genre)
        {
            var dbBook = context.Books.FirstOrDefault(e => e.BookID == book.ID);
            var dbGenre = context.Genres.FirstOrDefault(e => e.GenreID == genre.ID);
            if (dbBook != null && dbGenre!=null)
            {
                dbBook.Genres.Add(dbGenre);
            }
        }

        public void AddScreening(DalBook book, DalScreening screening)
        {
            var dbBook = context.Books.FirstOrDefault(e => e.BookID == book.ID);
            if (dbBook != null)
            {
                dbBook.Screenings.Add(screening.ToOrmScreening());
            }
        }

        public void AddTag(DalBook book, DalTag tag)
        {
            var dbBook = context.Books.FirstOrDefault(e => e.BookID == book.ID);
            var dbTag = context.Tags.FirstOrDefault(e => e.TagID == tag.ID);
            if (dbBook != null && dbTag!=null)
            {
                dbBook.Tags.Add(dbTag);
            }
        }

        public int Create(DalBook entity)
        {
            var obj = entity.ToOrmBook();
            context.Books.Add(obj);
            context.SaveChanges();
            return obj.BookID;
        }

        public void Delete(DalBook entity)
        {
            var book = context.Books.FirstOrDefault(e => e.BookID == entity.ID);
            if (book != null)
                context.Books.Remove(book);
        }

        public void DeleteAuthor(DalBook book, DalAuthor author)
        {
            var dbBook = context.Books.FirstOrDefault(e => e.BookID == book.ID);
            var dbAuthor = context.Authors.FirstOrDefault(e => e.AuthorID == author.ID);
            if (dbBook != null && dbAuthor!=null)
                dbBook.Authors.Remove(dbAuthor);
        }

        public void DeleteCover(DalCover cover)
        {
            var dbCover = context.Covers.FirstOrDefault(e => e.CoverID == cover.ID);
            if (dbCover != null)
                context.Covers.Remove(dbCover);
        }

        public void DeleteFile(DalFile file)
        {
            var dbFile = context.Files.FirstOrDefault(e =>e.FileID == file.ID);
            if (dbFile != null)
            {
                if (File.Exists(dbFile.Path))
                    File.Delete(dbFile.Path);
                context.Files.Remove(dbFile);
            }
        }

        public void DeleteGenre(DalBook book, DalGenre genre)
        {
            var dbGenre = context.Genres.FirstOrDefault(e => e.GenreID == genre.ID);
            var dbBook = context.Books.FirstOrDefault(e => e.BookID == book.ID);
            if (dbBook != null && dbGenre != null)
                dbBook.Genres.Remove(dbGenre);
        }

        public void DeleteScreening(DalScreening screening)
        {
            var dbScr = context.Screenings.FirstOrDefault(e => e.ScreeningID == screening.ID);
            if (dbScr != null)
                context.Screenings.Remove(dbScr);
        }

        public void DeleteTag(DalBook book, DalTag tag)
        {
            var dbTag = context.Tags.FirstOrDefault(e => e.TagID == tag.ID);
            var dbBook = context.Books.FirstOrDefault(e => e.BookID == book.ID);
            if (dbBook != null && dbTag != null)
                dbBook.Tags.Remove(dbTag);
        }

        public DalBook Find(Expression<Func<DalBook, bool>> f)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalBook> FindAll(Expression<Func<DalBook, bool>> f)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalBook> GetAll()
        {
            return context.Books.ToList().Select(e => e.ToDalBook());
        }

        public IEnumerable<DalAuthor> GetAuthors(DalBook book)
        {
            return
                context.Books.FirstOrDefault(e => e.BookID == book.ID)?.Authors.ToList().Select(e => e.ToDalAuthor()) ??
                new List<DalAuthor>();
        }

        public DalBook GetById(int key)
        {
            return context.Books.FirstOrDefault(e => e.BookID == key)?.ToDalBook();
        }

        public DalBook GetByName(string name)
        {
            return context.Books.FirstOrDefault(e => e.Name == name)?.ToDalBook();
        }

        public IEnumerable<DalCover> GetCovers(DalBook book)
        {
            var dbBook = context.Books.FirstOrDefault(e => e.BookID == book.ID);
            if (dbBook != null)
                return dbBook.Covers.Select(e=>e.ToDalCover());
            return new List<DalCover>();
        }

        public IEnumerable<DalFile> GetFiles(DalBook book)
        {
            var dbBook = context.Books.FirstOrDefault(e => e.BookID == book.ID);
            if (dbBook != null)
                return dbBook.Files.Select(e => e.ToDalFile());
            return new List<DalFile>();
        }

        public IEnumerable<DalGenre> GetGenres(DalBook book)
        {
            return context.Books.FirstOrDefault(e => e.BookID == book.ID)?.Genres.Select(e => e.ToDalGenre()) ??
                   new List<DalGenre>();
        }


        private static readonly Random Random = new Random();
        public DalBook GetRandomBook()
        {
            Books b = context.Books.FirstOrDefault();
            if (b != null)
            {
                int count = context.Books.Count();
                int r = Random.Next(b.BookID, count);
                Books result = context.Books.FirstOrDefault(e => e.BookID > r);
                return result.ToDalBook();
            }
            return null;
        }

        public IEnumerable<DalScreening> GetScreenings(DalBook book)
        {
            var dbBook = context.Books.FirstOrDefault(e => e.BookID == book.ID);
            if (dbBook != null)
                return dbBook.Screenings.Select(e => e.ToDalScreening());
            return new List<DalScreening>();
        }

        public IEnumerable<DalTag> GetTags(DalBook book)
        {
            return context.Books.FirstOrDefault(e => e.BookID == book.ID)?.Tags.Select(e => e.ToDalTag()) ??
                   new List<DalTag>();
        }

        public void Update(DalBook entity)
        {
            var a = context.Books.FirstOrDefault(e => e.BookID == entity.ID);
            if (a != null)
            {
                a.Age_Caegory = entity.AgeCategory;
                a.First_Publication = entity.FirstPublication;
                a.Name = entity.Name;
            }
        }

        public IEnumerable<DalList> GetLists(DalBook book)
        {
            return context.Books.FirstOrDefault(e => e.BookID == book.ID)?.Lists.Select(e => e.ToDalList()) ??
                   new List<DalList>();
        }
    }
}
