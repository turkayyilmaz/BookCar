using CarBook.Application.Features.Mediator.Commands.FooterAdressCommands;
using CarBook.Application.Features.Mediator.Commands.LocationCommands;
using CarBook.Application.Features.Mediator.Queries.LocationQueries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
	[Authorize(Roles = "Admin")]
	[Route("api/[controller]")]
	[ApiController]
	public class LocationController : ControllerBase
	{
		private readonly IMediator _mediator;
		public LocationController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpGet]
		public async Task<IActionResult> GetLocationList()
		{
			var values = await _mediator.Send(new GetLocationQuery());
			return Ok(values);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetLocationById(int id)
		{
			var value = await _mediator.Send(new GetLocationByIdQuery(id));
			return Ok(value);
		}
		[HttpPost]
		public async Task<IActionResult> CreateLocation(CreateLocationCommand command)
		{
			await _mediator.Send(command);
			return Ok("Location oluşturuldu.");
		}
		[HttpDelete]
		public async Task<IActionResult> DeleteLocation(int id)
		{
			await _mediator.Send(new RemoveLocationCommand(id));
			return Ok("Location silindi.");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateLocation(UpdateLocationCommand command)
		{
			await _mediator.Send(command);
			return Ok("Location güncellendi.");
		}
	}
}
