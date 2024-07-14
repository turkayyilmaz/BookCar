using CarBook.Application.Features.Mediator.Commands.ServiceCommands;
using CarBook.Application.Features.Mediator.Queries.ServiceQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ServiceController : ControllerBase
	{
		private readonly IMediator _mediator;
		public ServiceController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpGet]
		public async Task<IActionResult> GetServiceList()
		{
			var values = await _mediator.Send(new GetServiceQuery());
			return Ok(values);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetServiceById(int id)
		{
			var value = await _mediator.Send(new GetServiceByIdQuery(id));
			return Ok(value);
		}
		[HttpPost]
		public async Task<IActionResult> CreateService(CreateServiceCommand command)
		{
			await _mediator.Send(command);
			return Ok("Service oluşturuldu.");
		}
		[HttpDelete]
		public async Task<IActionResult> DeleteService(int id)
		{
			await _mediator.Send(new RemoveServiceCommand(id));
			return Ok("Service silindi.");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateService(UpdateServiceCommand command)
		{
			await _mediator.Send(command);
			return Ok("Service güncellendi.");
		}
	}
}
