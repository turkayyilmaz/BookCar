using CarBook.Application.RepositoryPattern;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarBook.Application.RepositoryPattern;
using CarBook.Domain.Entites;
using MediatR;
using CarBook.Application.Features.Mediator.Handlers.CommentHandlers;
using CarBook.Application.Features.Mediator.Commands.CommentCommands;
namespace CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CommentController : ControllerBase
	{
		private readonly IGenericRepository<Comment> _generic;
		private readonly IMediator _mediator;
		public CommentController(IGenericRepository<Comment> generic, IMediator mediator)
		{
			_generic = generic;
			_mediator = mediator;
		}
		[HttpGet]
		public IActionResult CommentList()
		{
			var values = _generic.GetAll();
			return Ok(values);
		}
		[HttpPost]
		public IActionResult CreateComment(Comment comment)
		{
			_generic.Create(comment);
			return Ok("Yorum başarıyla eklendi.");
		}
		[HttpDelete]
		public IActionResult RemoveComment(int id)
		{
			var value = _generic.GetById(id);
			_generic.Remove(value);
			return Ok("Yorum başarıyla silindi.");
		}
		[HttpPut]
		public IActionResult UpdateComment(Comment comment)
		{
			_generic.Update(comment);
			return Ok("Yorum başarıyla güncellendi.");
		}
		[HttpGet("{id}")]
		public IActionResult CreateComment(int id)
		{
			var value = _generic.GetById(id);
			return Ok(value);
		}
		[HttpGet("CommentListByBlog")]
		public IActionResult CommentListByBlog(int id)
		{
			var value = _generic.GetCommentByBlogId(id);
			return Ok(value);
		}
		[HttpGet("GetCountCommentByBlog")]
		public IActionResult GetCountCommentByBlog(int id)
		{
			var value = _generic.GetCountCommentByBlog(id);
			return Ok(value);
		}
		[HttpPost("CreateCommentWithMediator")]
		public async Task<IActionResult> CreateCommentWithMediator(CreateCommentCommand command)
		{
			await _mediator.Send(command);
			return Ok("Yorum Başarıyla Eklendi.");
		}
	}
}
