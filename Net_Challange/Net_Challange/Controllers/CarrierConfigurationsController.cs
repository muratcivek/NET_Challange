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
    public class CarrierConfigurationsController : ControllerBase
    {
        private IMediator _mediator;

        public CarrierConfigurationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CreateCarrierConfigurationCommand createCarrierConfigurationCommand)
        {
            CreateCarrierConfigurationResponse response = await _mediator.Send(createCarrierConfigurationCommand);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync([FromBody] DeleteCarrierConfigurationCommand deleteCarrierConfigurationCommand)
        {
            DeleteCarrierConfigurationResponse response = await _mediator.Send(deleteCarrierConfigurationCommand);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateCarrierConfigurationCommand updateCarrierConfigurationCommand)
        {
            UpdateCarrierConfigurationResponse response = await _mediator.Send(updateCarrierConfigurationCommand);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {

            List<GetAllCarrierConfigurationResponse> response = await _mediator.Send(new GetAllCarrierConfigurationQuery());
            return Ok(response);
        }
    }
}
