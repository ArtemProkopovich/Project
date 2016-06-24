using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfacies.Entities;
using DataAccess.Interfacies.Interfacies;
using DataAccessLibrary.Additional;
using DataAccessLibrary.Mappers;
using ORMLibrary;

namespace DataAccessLibrary.Repository
{
    public class ContentRepository : IContentRepository
    {
        private readonly DatabaseContext context;
        public ContentRepository(DatabaseContext context)
        {
            this.context = context;
        }

        public int Create(DalContent entity)
        {
            var dbBook = context.Books.FirstOrDefault(e => e.BookID == entity.BookID);
            var dbUser = context.Users.FirstOrDefault(e => e.UserID == entity.UserID);
            if (dbBook != null && dbUser != null)
            {
                context.Contents.Add(entity.ToOrmContent());
            }
            return 0;
        }

        public void Delete(DalContent entity)
        {
            var dbContent = context.Contents.FirstOrDefault(e => e.ContentID == entity.ID);
            if (dbContent != null)
                context.Contents.Remove(dbContent);
        }

        public DalContent Find(Expression<Func<DalContent, bool>> f)
        {
            var lambda = ExpressionTranslator.Translate<DalContent, Contents>(f, dictionary);
            return context.Contents.FirstOrDefault(lambda)?.ToDalContent();
        }

        public IEnumerable<DalContent> FindAll(Expression<Func<DalContent, bool>> f)
        {
            var lambda = ExpressionTranslator.Translate<DalContent, Contents>(f, dictionary);
            return context.Contents.Where(lambda).ToList().Select(e => e.ToDalContent());
        }

        private readonly Dictionary<string, string> dictionary = new Dictionary<string, string>()
        {
            {"ID", "ContentID"},
            {"BookID", "BookID"},
            {"UserID", "UserID"}
        };

        public IEnumerable<DalContent> GetAll()
        {
            return context.Contents.ToList().Select(e => e.ToDalContent());
        }

        public DalContent GetById(int key)
        {
            return context.Contents.FirstOrDefault(e => e.ContentID == key)?.ToDalContent();
        }

        public void Update(DalContent entity)
        {
            throw new NotImplementedException();
        }
    }
}
