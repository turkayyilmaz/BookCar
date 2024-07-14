using CarBook.Application.Features.Mediator.Commands.LocationCommands;
using CarBook.Application.Features.Mediator.Commands.TagCloudCommands;
using CarBook.Application.Features.Mediator.Queries.LocationQueries;
using CarBook.Application.Features.Mediator.Queries.TagCloudsQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TagCloudController : ControllerBase
	{
		private readonly IMediator _mediator;
		public TagCloudController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpGet]
		public async Task<IActionResult> GetTagCloudList()
		{
			var values = await _mediator.Send(new GetTagCloudQuery());
			return Ok(values);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetTagCloudById(int id)
		{
			var value = await _mediator.Send(new GetTagCloudByIdQuery(id));
			return Ok(value);
		}
		[HttpPost]
		public async Task<IActionResult> CreateTagCloud(CreateTagCloudCommand command)
		{
			await _mediator.Send(command);
			return Ok("TagCloud oluşturuldu.");
		}
		[HttpDelete]
		public async Task<IActionResult> DeleteTagCloud(int id)
		{
			await _mediator.Send(new RemoveTagCloudCommand(id));
			return Ok("TagCloud silindi.");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateTagCloud(UpdateTagCloudCommand command)
		{
			await _mediator.Send(command);
			return Ok("TagCloud güncellendi.");
		}
		[HttpGet("GetTagCloudByBlogId")]
		public async Task<IActionResult> GetTagCloudByBlogId(int id)
		{
			var values = await _mediator.Send(new GetTagCloudByBlogIdQuery(id));
			return Ok(values);
		}
	}
}
