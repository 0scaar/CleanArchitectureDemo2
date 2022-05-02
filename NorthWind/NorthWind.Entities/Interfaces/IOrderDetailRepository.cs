using NorthWind.Entities.POCOEntities;

namespace NorthWind.Entities.Interfaces
{
    public interface IOrderDetailRepository
    {
        void Create(OrderDetail orderDetail);
    }
}
