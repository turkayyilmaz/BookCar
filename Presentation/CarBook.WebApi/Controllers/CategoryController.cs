using CarBook.Application.Features.CQRS.Commands.CategoryCommands;
using CarBook.Application.Features.CQRS.Handlers.CategoryHandler;
using CarBook.Application.Features.CQRS.Handlers.CategoryHandler;
using CarBook.Application.Features.CQRS.Queries.CategoryQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		private readonly CreateCategoryCommandHandler _createCategoryCommandHandler;
		private readonly GetCategoryByIdQueryHandler _getCategoryByIdQueryHandler;
		private readonly GetContactyQueryHandler _getCategoryQueryHandler;
		private readonly UpdateCategoryCommandHandler _updateCategoryCommandHandler;
		private readonly RemoveCategoryCommandHandler _removeCategoryCommandHandler;

		public CategoryController(CreateCategoryCommandHandler createCategoryCommandHandler,
			GetCategoryByIdQueryHandler getCategoryByIdQueryHandler,
			GetContactyQueryHandler getCategoryQueryHandler,
			UpdateCategoryCommandHandler updateCategoryCommandHandler,
			RemoveCategoryCommandHandler removeCategoryCommandHandler)
		{
			_createCategoryCommandHandler = createCategoryCommandHandler;
			_getCategoryByIdQueryHandler = getCategoryByIdQueryHandler;
			_getCategoryQueryHandler = getCategoryQueryHandler;
			_updateCategoryCommandHandler = updateCategoryCommandHandler;
			_removeCategoryCommandHandler = removeCategoryCommandHandler;
		}
		[HttpGet]
		public async Task<IActionResult> CategoryList()
		{
			var values = await _getCategoryQueryHandler.Handle();
			return Ok(values);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetCategory(int id)
		{
			var value = await _getCategoryByIdQueryHandler.Handle(new GetCategoryByIdQuery(id));
			return Ok(value);
		}
		[HttpPost]
		public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
		{
			await _createCategoryCommandHandler.Handle(command);
			return Ok("Category Bilgisi Eklendi.");
		}
		[HttpDelete]
		public async Task<IActionResult> RemoveCategory(int id)
		{
			await _removeCategoryCommandHandler.Handle(new RemoveCategoryCommand(id));
			return Ok("Category Bilgisi Silindi.");
		}
		[HttpPut]
		public async Task<IActionResult> Update(UpdateCategoryCommand command)
		{
			await _updateCategoryCommandHandler.Handle(command);
			return Ok("Category Bilgisi Güncellendi.");
		}
	}
}
