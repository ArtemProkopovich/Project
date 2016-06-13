using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfacies;
using DataAccess.Interfacies.Entities;
using DataAccessLibrary.Mappers;
using ORMLibrary;

namespace DataAccessLibrary.Repository
{
    public class TagRepository : ITagRepository
    {
        private readonly DatabaseContext context;
        public TagRepository(DatabaseContext context)
        {
            this.context = context;
        }
        public int Create(DalTag entity)
        {
            var obj = entity.ToOrmTag();
            context.Tags.Add(obj);
            context.SaveChanges();
            return obj.TagID;
        }

        public void Delete(DalTag entity)
        {
            var t = context.Tags.FirstOrDefault(e => e.TagID == entity.ID);
            if (t != null)
                context.Tags.Remove(t);
        }

        public DalTag Find(Expression<Func<DalTag, bool>> f)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalTag> FindAll(Expression<Func<DalTag, bool>> f)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalTag> GetAll()
        {
            var tags = context.Tags.ToList();
            return tags.Select(e => e.ToDalTag());
        }

        public IEnumerable<DalBook> GetBooks(DalTag tag)
        {
            return context.Tags.FirstOrDefault(e => e.TagID == tag.ID)?.Books.Select(e => e.ToDalBook());
        }

        public DalTag GetById(int key)
        {
            return context.Tags.FirstOrDefault(e => e.TagID == key)?.ToDalTag();
        }

        public DalTag GetByName(string name)
        {
            return context.Tags.FirstOrDefault(e => e.Name == name)?.ToDalTag();
        }

        public void Update(DalTag entity)
        {
            var g = context.Tags.FirstOrDefault(e => e.TagID == entity.ID);
            if (g != null)
            {
                g.Name = entity.Name;
            }
        }
    }
}
