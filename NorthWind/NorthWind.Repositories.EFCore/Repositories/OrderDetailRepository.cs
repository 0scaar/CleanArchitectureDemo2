using Microsoft.EntityFrameworkCore;
using NorthWind.Entities.Interfaces;
using NorthWind.Entities.POCOEntities;
using NorthWind.Entities.Specifications;
using NorthWind.Repositories.EFCore.DataContext;
using System.Collections.Generic;
using System.Linq;

namespace NorthWind.Repositories.EFCore.Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        readonly NorthWindContext context;

        public OrderDetailRepository(NorthWindContext context)
        {
            this.context = context;
        }

        public void Create(OrderDetail orderDetail)
        {
            context.Add(orderDetail);
        }

        public IEnumerable<OrderDetail> GetOrdersDetailByEspecification(Specification<OrderDetail> specification)
        {
            var expressionDelegate = specification.Expression.Compile();
            return context.OrderDetails
                .Include(i => i.Order)
                .Where(expressionDelegate);
        }
    }
}
