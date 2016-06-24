﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLibrary
{
    internal class CustomExpressionVisitor<T> : ExpressionVisitor
    {
        ParameterExpression parameter;

        //there must be only one instance of parameter expression for each parameter 
        //there is one so one passed here
        public CustomExpressionVisitor(ParameterExpression parameter)
        {
            this.parameter = parameter;
        }

        //this method replaces original parameter with given in constructor
        protected override Expression VisitParameter(ParameterExpression node)
        {
            return this.parameter;
        }

        //this one is required because PersonData does not implement IPerson and it finds
        //property in PersonData with the same name as the one referenced in expression 
        //and declared on IPerson
        protected override Expression VisitMember(MemberExpression node)
        {
            if (node.Member.MemberType != System.Reflection.MemberTypes.Property)
                throw new NotImplementedException();

            //name of a member referenced in original expression in your 
            //sample Id in mine Prop
            var memberName = node.Member.Name;
            //find property on type T (=PersonData) by name
            var otherMember = typeof(T).GetProperty(memberName);
            //visit left side of this expression p.Id this would be p
            var inner = Visit(node.Expression);

            return Expression.Property(inner, otherMember);
        }

    }
}
