using MediatR;
using NorthWind.Entities.Exceptions;
using NorthWind.Entities.Interfaces;
using NorthWind.Entities.POCOEntities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NorthWind.UseCases.CreateOrder
{
    public class CreateOrderInteractor : AsyncRequestHandler<CreateOrderInputPort>
    {
        readonly IOrderRepository orderRepository;
        readonly IOrderDetailRepository orderDetailRepository;
        readonly IUnitOfWork unitOfWork;

        public CreateOrderInteractor(IOrderRepository orderRepository, 
            IOrderDetailRepository orderDetailRepository, 
            IUnitOfWork unitOfWork)
        {
            this.orderRepository = orderRepository;
            this.orderDetailRepository = orderDetailRepository;
            this.unitOfWork = unitOfWork;
        }

        protected async override Task Handle(CreateOrderInputPort request, 
            CancellationToken cancellationToken)
        {
            var order = new Order
            {
                CustomerId = request.RequestData.CustomerId,
                OrderDate = DateTime.Now,
                ShipAddress = request.RequestData.ShipAddress,
                ShipCity = request.RequestData.ShipCity,
                ShipCountry = request.RequestData.ShipCountry,
                ShipPostalCode = request.RequestData.ShipPostalCode,
                shippingType = Entities.Enums.ShippingType.Road,
                DiscountType = Entities.Enums.DiscountType.Percentage,
                Discount = 10
            };

            orderRepository.Create(order);

            foreach(var item in request.RequestData.OrderDetails)
            {
                orderDetailRepository.Create(new OrderDetail
                {
                    Order = order,
                    ProductId = item.ProductId,
                    UnitPrice = item.UnitPrice,
                    Quantity = item.Quantity
                });
            }

            try
            {
                await unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new GeneralException("Error creating order", ex.Message);
            }

            request.OutputPort.Handler(order.Id);
        }
    }
}
