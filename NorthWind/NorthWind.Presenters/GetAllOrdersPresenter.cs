using NorthWind.Presenters.GetAllOrdersDTO;
using NorthWind.UseCases.GetAllOrders;
using System.Linq;

namespace NorthWind.Presenters
{
    public class GetAllOrdersPresenter : IPresenter<GetAllOrdersOutputPort, GetAllOrdersOutput>
    {
        public GetAllOrdersOutput Content { get; private set; }

        public void Handler(GetAllOrdersOutputPort response)
        {
            var orders = response.Orders
                .Select(s => new Order
                {
                    OrderDate = s.OrderDate,
                    ShipAddress = s.ShipAddress,
                    ShipCity = s.ShipCity,
                    ShipCountry = s.ShipCountry,
                    ShipPostalCode = s.ShipPostalCode,
                    DiscountType = s.DiscountType,
                    Discount = s.Discount,
                    shippingType = s.shippingType,
                    OrderDetails = s.OrderDetails
                        .Select(od => new OrderDetail
                        {
                            Product = od.Product,
                            UnitPrice = od.UnitPrice,
                            Quantity = od.Quantity
                        }).ToList()
                })
                .ToList();

            Content = new GetAllOrdersOutput() 
            { 
                Orders = orders 
            };
        }
    }
}
