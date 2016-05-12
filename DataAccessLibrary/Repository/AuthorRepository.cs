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
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ProjectDataEntities context;
        public AuthorRepository(ProjectDataEntities context)
        {
            this.context = context;
        }

        public int Create(DalAuthor entity)
        {
            Authors author = context.Authors.Add(entity.ToOrmAuthor());
            return author.AuthorID;
        }

        public void Delete(DalAuthor entity)
        {
            var a = context.Authors.FirstOrDefault(e => e.AuthorID == entity.ID);
            if (a != null)
                context.Authors.Remove(a);
        }

        public DalAuthor Find(Expression<Func<DalAuthor, bool>> f)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalAuthor> FindAll(Expression<Func<DalAuthor, bool>> f)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalAuthor> GetAll()
        {
            return context.Authors.ToList().Select(e=>e.ToDalAuthor());
        }

        public IEnumerable<DalBook> GetBooks(DalAuthor author)
        {
            return context.Books.Where(e => e.Authors.AsQueryable().Any(t => t.AuthorID == author.ID))
                .Select(r => r.ToDalBook());
        }

        public DalAuthor GetById(int key)
        {
            return context.Authors.FirstOrDefault(e => e.AuthorID == key)?.ToDalAuthor();
        }

        public void Update(DalAuthor entity)
        {
            var a = context.Authors.FirstOrDefault(e => e.AuthorID == entity.ID);
            if (a != null)
            {
                a.Biography = entity.Biography;
                a.Birth_Date = entity.BirthDate;
                a.Death_Date = entity.DeathDate;
                a.Name = entity.Name;
            }
        }
    }
}
