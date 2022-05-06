using MediatR;
using Microsoft.AspNetCore.Mvc;
using NorthWind.Presenters;
using NorthWind.UseCases.CreateOrder;
using NorthWind.UseCasesDTOs.CreateOrder;
using System.Threading.Tasks;

namespace NorthWind.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController
    {
        readonly IMediator mediator;

        public OrderController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("createOrder")]
        public async Task<string> CreateOrder(CreateOrderParams orderParams)
        {
            var presenter = new CreateOrderPresenter();
            await mediator.Send(new CreateOrderInputPort(orderParams, presenter));

            return presenter.Content;
        }
    }
}
