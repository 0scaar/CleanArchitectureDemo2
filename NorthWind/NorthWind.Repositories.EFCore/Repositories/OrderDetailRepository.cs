using NorthWind.Entities.Interfaces;
using NorthWind.Entities.POCOEntities;
using NorthWind.Repositories.EFCore.DataContext;

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
    }
}
