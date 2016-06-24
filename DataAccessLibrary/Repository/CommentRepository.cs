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
    public class CommentRepository : ICommentRepository
    {
        private readonly DatabaseContext context;
        public CommentRepository(DatabaseContext context)
        {
            this.context = context;
        }
        public int Create(DalComment entity)
        {
            var dbBook = context.Books.FirstOrDefault(e => e.BookID == entity.BookID);
            var dbUser = context.Users.FirstOrDefault(e => e.UserID == entity.UserID);
            if (dbBook != null && dbUser != null)
            {
                context.Comments.Add(entity.ToOrmComment());
            }
            return 0;
        }

        public void Delete(DalComment entity)
        {
            var dbComment = context.Comments.FirstOrDefault(e => e.CommentID == entity.ID);
            if (dbComment != null)
                context.Comments.Remove(dbComment);
        }

        public DalComment Find(Expression<Func<DalComment, bool>> f)
        {
            var lambda = ExpressionTranslator.Translate<DalComment, Comments>(f, dictionary);
            return context.Comments.FirstOrDefault(lambda)?.ToDalComment();
        }

        public IEnumerable<DalComment> FindAll(Expression<Func<DalComment, bool>> f)
        {
            var lambda = ExpressionTranslator.Translate<DalComment, Comments>(f, dictionary);
            return context.Comments.Where(lambda).ToList().Select(e => e.ToDalComment());
        }

        private readonly Dictionary<string, string> dictionary = new Dictionary<string, string>()
        {
            {"ID", "CollectionID"},
            {"BookID", "BookID"},
            {"UserID", "UserID"}
        };

        public IEnumerable<DalComment> GetAll()
        {
            return context.Comments.ToList().Select(e => e.ToDalComment());
        }

        public DalComment GetById(int key)
        {
            return context.Comments.FirstOrDefault(e => e.CommentID == key)?.ToDalComment();
        }

        public void Update(DalComment entity)
        {
            throw new NotImplementedException();
        }
    }
}
