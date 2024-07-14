using CarBook.Application.Features.Mediator.Commands.FeaturesCommands;
using CarBook.Application.Features.Mediator.Queries.FeaturesQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FeatureController : ControllerBase
	{
		private readonly IMediator _mediator;
		public FeatureController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpGet]
		public async Task<IActionResult> FeatureList()
		{
			var value = await _mediator.Send(new GetFeatureQuery());
			return Ok(value);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetFeature(int id)
		{
			var value = await _mediator.Send(new GetFeatureByIdQuery(id));
			return Ok(value);
		}
		[HttpPost]
		public async Task<IActionResult> CreateFeature(CreateFeatureCommand command)
		{
			await _mediator.Send(command); //istek yapılan CreateFeatureCommandı kendi buluyor
			return Ok("Feature başarıyla oluşturuldu.");
		}
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteFeature(int id)
		{
			await _mediator.Send(new RemoveFeatureCommand(id));
			return Ok("Feature başarıyla silindi.");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateFeature(UpdateFeatureCommand command)
		{
			await _mediator.Send(command);
			return Ok("Feature başarıyla güncellendi.");
		}
	}
}
