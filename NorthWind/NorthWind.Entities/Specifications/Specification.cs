using System;
using System.Linq.Expressions;

namespace NorthWind.Entities.Specifications
{
    public abstract class Specification<T>
    {
        public Expression<Func<T, bool>> Expression { get; set; }

        public bool IsSatisfieldBy(T entity)
        {
            Func<T, bool> expressionDelegate = Expression.Compile();

            return expressionDelegate(entity);
        }
    }
}
