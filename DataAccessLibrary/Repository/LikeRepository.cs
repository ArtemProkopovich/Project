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
    public class LikeRepository : ILikeRepository
    {
        private readonly DatabaseContext context;
        public LikeRepository(DatabaseContext context)
        {
            this.context = context;
        }

        public int Create(DalLike entity)
        {
            var dbBook = context.Books.FirstOrDefault(e => e.BookID == entity.BookID);
            var dbUser = context.Users.FirstOrDefault(e => e.UserID == entity.UserID);
            if (dbBook != null && dbUser != null)
            {
                context.Likes.Add(entity.ToOrmLike());
            }
            return 0;
        }

        public void Delete(DalLike entity)
        {
            var dbLike = context.Likes.FirstOrDefault(e => e.LikeID == entity.ID);
            if (dbLike != null)
                context.Likes.Remove(dbLike);
        }

        public DalLike Find(Expression<Func<DalLike, bool>> f)
        {
            var lambda = ExpressionTranslator.Translate<DalLike, Likes>(f, dictionary);
            return context.Likes.FirstOrDefault(lambda)?.ToDalLike();
        }

        public IEnumerable<DalLike> FindAll(Expression<Func<DalLike, bool>> f)
        {
            var lambda = ExpressionTranslator.Translate<DalLike, Likes>(f, dictionary);
            return context.Likes.Where(lambda).ToList().Select(e => e.ToDalLike());
        }

        private readonly Dictionary<string, string> dictionary = new Dictionary<string, string>()
        {
            {"ID", "LikeID"},
            {"BookID", "BookID"},
            {"UserID", "UserID"}
        };

        public IEnumerable<DalLike> GetAll()
        {
            throw new NotImplementedException();
        }

        public DalLike GetById(int key)
        {
            throw new NotImplementedException();
        }

        public void Update(DalLike entity)
        {
            var dbLike = context.Likes.FirstOrDefault(e => e.LikeID == entity.ID);
            var l = context.Entry(dbLike);
            l.Entity.Like = entity.Like;
            l.State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
