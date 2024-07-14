using CarBook.Application.Features.Mediator.Commands.BlogCommands;
using CarBook.Application.Features.Mediator.Commands.LocationCommands;
using CarBook.Application.Features.Mediator.Handlers.BlogHandlers;
using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Queries.LocationQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BlogController : ControllerBase
	{
		private readonly IMediator _mediator;
		public BlogController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpGet]
		public async Task<IActionResult> GetBlogList()
		{
			var values = await _mediator.Send(new GetBlogQuery());
			return Ok(values);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetBlogById(int id)
		{
			var value = await _mediator.Send(new GetBlogQueryById(id));
			return Ok(value);
		}
		[HttpPost]
		public async Task<IActionResult> CreateBlog(CreateBlogCommand command)
		{
			await _mediator.Send(command);
			return Ok("Blog oluşturuldu.");
		}
		[HttpDelete]
		public async Task<IActionResult> DeleteBlog(int id)
		{
			await _mediator.Send(new RemoveBlogCommand(id));
			return Ok("Blog silindi.");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateBlog(UpdateBlogCommand command)
		{
			await _mediator.Send(command);
			return Ok("Blog güncellendi.");
		}
		[HttpGet("GetLast3BlogsWithAuthors")]
		public async Task<IActionResult> GetLast3BlogsWithAuthorsList()
		{
			var values = await _mediator.Send(new GetLast3BlogsWithAuthorsQuery());
			return Ok(values);
		}
		[HttpGet("GetAllBlogWithAuthorList")]
		public async Task<IActionResult> GetAllBlogsWithAuthorsList()
		{
			var values = await _mediator.Send(new GetAllBlogWithAuthorQuery());
			return Ok(values);
		}
		[HttpGet("GetBlogByAuthorId")]
		public async Task<IActionResult> GetBlogByAuthorId(int id)
		{
			var values = await _mediator.Send(new GetBlogByAuthorIdQuery(id));
			return Ok(values);
		}
	}
}
