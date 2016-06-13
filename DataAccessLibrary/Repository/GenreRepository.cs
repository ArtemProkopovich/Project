using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    public class GenreRepository : IGenreRepository
    {
        private readonly DatabaseContext context;
        public GenreRepository(DatabaseContext context)
        {
            this.context = context;
        }
        public int Create(DalGenre entity)
        {
            var obj = entity.ToOrmGenre();
            context.Genres.Add(obj);
            context.SaveChanges();
            return obj.GenreID;
        }

        public void Delete(DalGenre entity)
        {
            var cl = context.Genres.FirstOrDefault(e => e.GenreID == entity.ID);
            if (cl != null)
                context.Genres.Remove(cl);
        }

        public DalGenre Find(Expression<Func<DalGenre, bool>> f)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalGenre> FindAll(Expression<Func<DalGenre, bool>> f)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalGenre> GetAll()
        {
            return context.Genres.ToList().Select(e => e.ToDalGenre());
        }

        public IEnumerable<DalBook> GetBooks(DalGenre genre)
        {
            return context.Genres.FirstOrDefault(e => e.GenreID == genre.ID)?.Books.Select(e => e.ToDalBook());
        }

        public DalGenre GetById(int key)
        {
            return context.Genres.FirstOrDefault(e => e.GenreID == key)?.ToDalGenre();
        }

        public DalGenre GetByName(string name)
        {
            return context.Genres.FirstOrDefault(e => e.Name == name)?.ToDalGenre();
        }

        public void Update(DalGenre entity)
        {
            var g = context.Genres.FirstOrDefault(e => e.GenreID == entity.ID);
            if (g != null)
            {
                g.Name = entity.Name;
            }
        }
    }
}
