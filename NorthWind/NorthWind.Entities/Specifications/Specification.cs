using System;
using System.Linq.Expressions;

namespace NorthWind.Entities.Specifications
{
    public class Specification<T>
    {
        public Expression<Func<T, bool>> Expression { get; private set; }

        public Specification(Expression<Func<T, bool>> expression)
        {
            Expression = expression;
        }

        public bool IsSatisfieldBy(T entity)
        {
            Func<T, bool> expressionDelegate = Expression.Compile();

            return expressionDelegate(entity);
        }
    }
}
