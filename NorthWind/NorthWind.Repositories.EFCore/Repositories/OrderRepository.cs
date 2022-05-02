using NorthWind.Entities.Interfaces;
using NorthWind.Entities.POCOEntities;
using NorthWind.Entities.Specifications;
using NorthWind.Repositories.EFCore.DataContext;
using System.Collections.Generic;
using System.Linq;

namespace NorthWind.Repositories.EFCore.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        readonly NorthWindContext context;

        public OrderRepository(NorthWindContext context)
        {
            this.context = context;
        }

        public void Create(Order order)
        {
            context.Add(order);
        }

        public IEnumerable<Order> GetOrdersByEspecification(Specification<Order> specification)
        {
            var expressionDelegate = specification.Expression.Compile();
            return context.Orders.Where(expressionDelegate);
        }
    }
}
