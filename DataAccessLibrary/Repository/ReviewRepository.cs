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
    public class ReviewRepository : IReviewRepository
    {
        private readonly DatabaseContext context;
        public ReviewRepository(DatabaseContext context)
        {
            this.context = context;
        }

        public int Create(DalReview entity)
        {
            var dbBook = context.Books.FirstOrDefault(e => e.BookID == entity.BookID);
            var dbUser = context.Users.FirstOrDefault(e => e.UserID == entity.UserID);
            if (dbBook != null && dbUser != null)
            {
                context.Reviews.Add(entity.ToOrmReview());
            }
            return 0;
        }

        public void Delete(DalReview entity)
        {
            var dbReview = context.Reviews.FirstOrDefault(e => e.ReviewID == entity.ID);
            if (dbReview != null)
                context.Reviews.Remove(dbReview);
        }

        public DalReview Find(Expression<Func<DalReview, bool>> f)
        {
            var lambda = ExpressionTranslator.Translate<DalReview, Reviews>(f, dictionary);
            return context.Reviews.FirstOrDefault(lambda)?.ToDalReview();
        }

        public IEnumerable<DalReview> FindAll(Expression<Func<DalReview, bool>> f)
        {
            var lambda = ExpressionTranslator.Translate<DalReview, Reviews>(f, dictionary);
            return context.Reviews.Where(lambda).ToList().Select(e => e.ToDalReview());
        }

        private readonly Dictionary<string, string> dictionary = new Dictionary<string, string>()
        {
            {"ID", "ReviewID"},
            {"BookID", "BookID"},
            {"UserID", "UserID"}
        };

        public IEnumerable<DalReview> GetAll()
        {
            throw new NotImplementedException();
        }

        public DalReview GetById(int key)
        {
            throw new NotImplementedException();
        }

        public void Update(DalReview entity)
        {
            throw new NotImplementedException();
        }
    }
}
