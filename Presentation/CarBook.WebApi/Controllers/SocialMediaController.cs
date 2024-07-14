using CarBook.Application.Features.Mediator.Commands.SocialMediaCommands;
using CarBook.Application.Features.Mediator.Queries.SocialMediaQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SocialMediaController : ControllerBase
	{
		private readonly IMediator _mediator;
		public SocialMediaController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpGet]
		public async Task<IActionResult> GetSocialMediaList()
		{
			var values = await _mediator.Send(new GetSocialMediaQuery());
			return Ok(values);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetSocialMediaById(int id)
		{
			var value = await _mediator.Send(new GetSocialMediaByIdQuery(id));
			return Ok(value);
		}
		[HttpPost]
		public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaCommand command)
		{
			await _mediator.Send(command);
			return Ok("SocialMedia oluşturuldu.");
		}
		[HttpDelete]
		public async Task<IActionResult> DeleteSocialMedia(int id)
		{
			await _mediator.Send(new RemoveSocialMediaCommand(id));
			return Ok("SocialMedia silindi.");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaCommand command)
		{
			await _mediator.Send(command);
			return Ok("SocialMedia güncellendi.");
		}
	}
}
