using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Additional
{
    public class SimpleExpressionVisitor<T1,T2>:ExpressionVisitor
    {
        ParameterExpression parameter;
        private Dictionary<string, string> dictionary;

        //there must be only one instance of parameter expression for each parameter 
        //there is one so one passed here
        public SimpleExpressionVisitor(ParameterExpression parameter, Dictionary<string, string> dictionary)
        {
            this.parameter = parameter;
            this.dictionary = dictionary;
        }

        //this method replaces original parameter with given in constructor
        protected override Expression VisitParameter(ParameterExpression node)
        {
            return parameter;
        }

        //this one is required because PersonData does not implement IPerson and it finds
        //property in PersonData with the same name as the one referenced in expression 
        //and declared on IPerson
        protected override Expression VisitMember(MemberExpression node)
        {
            if (node.Member.MemberType != System.Reflection.MemberTypes.Property)
            {
                return node;
            }
            if (node.Member.ReflectedType.Name == typeof(T1).Name)
            {
                var memberName = node.Member.Name;
                PropertyInfo otherMember = typeof(T2).GetProperty(GetEqualParametrName(memberName));
                var inner = Visit(node.Expression);
                return Expression.Property(inner, otherMember);
            }
            return node;
        }

        private string GetEqualParametrName(string name)
        {
            foreach (var node in dictionary)
            {
                if (node.Key == name)
                    return node.Value;
            }
            return name;
        }
    }
}
