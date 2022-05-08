using MediatR;
using NorthWind.Entities.Exceptions;
using NorthWind.Entities.Interfaces;
using NorthWind.Entities.POCOEntities;
using NorthWind.Entities.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NorthWind.UseCases.GetAllOrders
{
    public class GetAllOrdersIterator : AsyncRequestHandler<GetAllOrdersInputPort>
    {
        readonly IOrderDetailRepository orderDetailRepository;
        readonly IProductRepository productRepository;

        public GetAllOrdersIterator(IOrderDetailRepository orderDetailRepository,
            IProductRepository productRepository
            )
        {
            this.orderDetailRepository = orderDetailRepository;
            this.productRepository = productRepository;
        }

        protected async override Task Handle(GetAllOrdersInputPort request, 
            CancellationToken cancellationToken)
        {
            var output = new GetAllOrdersOutputPort();
            output.Orders = new List<GetAllOrder>();

            try
            {
                var expressionOrderDetail = new Specification<OrderDetail>(s => s.Order.CustomerId.ToLower() == request.RequestData.CustomerId.ToLower());
                var ordersDetail = orderDetailRepository.GetOrdersDetailByEspecification(expressionOrderDetail).ToList();

                var productsId = ordersDetail.Select(s => s.ProductId).Distinct().ToList();
                var expressionProduct = new Specification<Product>(s => productsId.Contains(s.Id));
                var products = productRepository.GetProductsByEspecification(expressionProduct).ToList();

                var ordersId = ordersDetail.Select(s => s.Order.Id).Distinct().ToList();

                foreach(var id in ordersId)
                {
                    var order = ordersDetail
                        .Where(s => s.Order.Id == id)
                        .Select(s => new GetAllOrder(
                            s.Order.OrderDate,
                            s.Order.ShipAddress,
                            s.Order.ShipCity,
                            s.Order.ShipCountry,
                            s.Order.ShipPostalCode,
                            s.Order.DiscountType,
                            s.Order.Discount,
                            s.Order.shippingType
                            ))
                        .FirstOrDefault();

                    var detail = ordersDetail
                        .Where(f => f.Order.Id == id)
                        .Select(s => new GetAllOrderDetail(
                            products.FirstOrDefault(d => d.Id == s.ProductId).Name,
                            s.UnitPrice,
                            s.Quantity
                            ))
                        .ToList();

                    order.SetOrderDetails(detail);

                    output.Orders.Add(order); 
                }
            }
            catch (Exception ex)
            {
                throw new GeneralException("Error getting order", ex.Message);
            }

            request.OutputPort.Handler(output);
        }
    }
}
