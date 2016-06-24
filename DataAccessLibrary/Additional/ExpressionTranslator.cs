using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ORMLibrary;

namespace DataAccessLibrary.Additional
{
    public class ExpressionTranslator
    {
        public static Expression<Func<T2, bool>> Translate<T1, T2>(Expression<Func<T1, bool>> func,
            Dictionary<string, string> dictionary)
        {
            var param = Expression.Parameter(typeof (T2));
            var body = new SimpleExpressionVisitor<T1,T2>(param, dictionary).Visit(func.Body);
            Expression<Func<T2, bool>> lambda = Expression.Lambda<Func<T2, bool>>(body, param);
            return lambda;
        }
    }
}
