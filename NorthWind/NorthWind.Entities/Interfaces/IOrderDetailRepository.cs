using NorthWind.Entities.POCOEntities;
using NorthWind.Entities.Specifications;
using System.Collections.Generic;

namespace NorthWind.Entities.Interfaces
{
    public interface IOrderDetailRepository
    {
        void Create(OrderDetail orderDetail);
        IEnumerable<OrderDetail> GetOrdersDetailByEspecification(Specification<OrderDetail> specification);
    }
}
