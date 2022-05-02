using NorthWind.Entities.POCOEntities;
using NorthWind.Entities.Specifications;
using System.Collections.Generic;

namespace NorthWind.Entities.Interfaces
{
    public interface IOrderRepository
    {
        void Create(Order order);
        IEnumerable<Order> GetOrdersByEspecification(Specification<Order> specification);
    }
}
