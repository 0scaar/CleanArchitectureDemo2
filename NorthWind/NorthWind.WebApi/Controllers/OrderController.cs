using MediatR;
using Microsoft.AspNetCore.Mvc;
using NorthWind.UseCases.CreateOrder;
using System.Threading.Tasks;

namespace NorthWind.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        readonly IMediator mediator;

        public OrderController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateOrder(CreateOrderInputPort orderParams)
        {
            return await mediator.Send(orderParams);
        }
    }
}
