using NorthWind.Entities.Interfaces;
using NorthWind.Entities.POCOEntities;
using NorthWind.Entities.Specifications;
using NorthWind.Repositories.EFCore.DataContext;
using System.Collections.Generic;
using System.Linq;

namespace NorthWind.Repositories.EFCore.Repositories
{
    public class ProductRepository : IProductRepository
    {
        readonly NorthWindContext context;

        public ProductRepository(NorthWindContext context)
        {
            this.context = context;
        }

        public IEnumerable<Product> GetProductsByEspecification(Specification<Product> specification)
        {
            var expressionDelegate = specification.Expression.Compile();
            return context.Products.Where(expressionDelegate);
        }
    }
}
