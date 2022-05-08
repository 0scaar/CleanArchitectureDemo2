using MediatR;
using Microsoft.AspNetCore.Mvc;
using NorthWind.Presenters;
using NorthWind.Presenters.GetAllOrdersDTO;
using NorthWind.UseCases.GetAllOrders;
using NorthWind.UseCasesDTOs.GetAllOrders;
using System.Threading.Tasks;

namespace NorthWind.Controllers.Orders
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

        [HttpPost]
        [ProducesResponseType(typeof(GetAllOrdersOutput), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        [Route("GetAllOrdersByCustomer")]
        public async Task<GetAllOrdersOutput> GetAllOrdersByCustomer(GetAllOrdersParams input)
        {
            var presenter = new GetAllOrdersPresenter();
            await mediator.Send(new GetAllOrdersInputPort(input, presenter));

            return presenter.Content;
        }
    }
}
