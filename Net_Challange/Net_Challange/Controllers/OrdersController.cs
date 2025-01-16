using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetChallange.Application.Features.Commands.Create;
using NetChallange.Application.Features.Commands.Delete;
using NetChallange.Application.Features.Queries;

namespace NetChallange.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CreateOrderCommand createOrderCommand)
        {
            CreateOrderResponse response = await _mediator.Send(createOrderCommand);
            return Ok(response);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync([FromBody] DeleteOrderCommand deleteOrderCommand)
        {
            DeleteOrderResponse response = await _mediator.Send(deleteOrderCommand);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {

            List<GetAllOrdersResponse> response = await _mediator.Send(new GetAllOrdersQuery());
            return Ok(response);
        }
    }
}
