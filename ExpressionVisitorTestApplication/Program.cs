using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionVisitorTestApplication
{
    public class Entity1
    {
        public int EntityID { get; set; }
        public int Entity2ID { get; set; }
    }

    public class Entity2
    {
        public int ID { get; set; }
        public int ID2 { get; set; }
    }

    class Visitor<T1,T2> : ExpressionVisitor
    {
        ParameterExpression parameter;

        //there must be only one instance of parameter expression for each parameter 
        //there is one so one passed here
        public Visitor(ParameterExpression parameter)
        {
            this.parameter = parameter;
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
                PropertyInfo otherMember = typeof (T2).GetProperty(GetEqualParametrName(memberName));
                var inner = Visit(node.Expression);
                return Expression.Property(inner, otherMember);
            }
            return node;
                
        }

        private string GetEqualParametrName(string name)
        {
            foreach (var node in Dictionary)
            {
                if (node.Key == name)
                    return node.Value;
            }
            return "";
        }

        Dictionary<string, string> Dictionary = new Dictionary<string, string>()
        {
            {"EntityID", "ID"},
            {"Entity2ID", "ID2"}
        };
    }

    public class Entity3
    {
        public int ID;
    }


    class Program
    {
        static void Main(string[] args)
        {
            var e = new Entity3() {ID = 5};
            Expression<Func<Entity1, bool>> expression = x => x.EntityID == e.ID && x.Entity2ID == 2;
            var v = expression.Compile()(new Entity1 {EntityID = 4, Entity2ID = 3});
            Console.WriteLine(v);
            var param = Expression.Parameter(typeof (Entity2));
            var body = new Visitor<Entity1,Entity2>(param).Visit(expression.Body);
            Expression<Func<Entity2, bool>> lambda = Expression.Lambda<Func<Entity2, bool>>(body, param);
            var boolValue = lambda.Compile()(new Entity2() {ID = 5, ID2 = 3});
            Console.WriteLine(boolValue);
            Console.ReadLine();
        }
    }
}
