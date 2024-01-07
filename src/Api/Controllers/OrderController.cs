using Domain.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator mediator;

        public OrderController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route(""), ActionName("Get")]
        public async Task<IActionResult> Get()
        {
            var query = new GetOrderQuery();

            var result = await mediator.Send(query);

            return Ok(result);
        }

        [HttpGet]
        [Route("{orderId:guid}"), ActionName("GetById")]
        public async Task<IActionResult> GetById([FromRoute] Guid orderId)
        {
            var query = new GetOrderByIdQuery(orderId);

            var result = await mediator.Send(query);

            return Ok(result);
        }
    }
}
