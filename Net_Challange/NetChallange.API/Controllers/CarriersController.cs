using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetChallange.Application.Features.Commands.Create;
using NetChallange.Application.Features.Commands.Delete;
using NetChallange.Application.Features.Commands.Update;
using NetChallange.Application.Features.Queries;

namespace NetChallange.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarriersController : ControllerBase
    {
        private IMediator _mediator;

        public CarriersController(IMediator? mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CreateCarrierCommand createCarrierCommand)
        {
            CreateCarrierResponse response = await _mediator.Send(createCarrierCommand);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateCarrierCommand updateCarrierCommand)
        {
            UpdateCarrierResponse response = await _mediator.Send(updateCarrierCommand);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync([FromBody] DeleteCarrierCommand deleteCarrierCommand)
        {
            DeleteCarrierResponse response = await _mediator.Send(deleteCarrierCommand);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {

            List<GetAllCarriersResponse> response = await _mediator.Send(new GetAllCarriersQuery());
            return Ok(response);
        }

    }
}
