using CarBook.Application.Features.CQRS.Commands.BrandCommands;
using CarBook.Application.Features.CQRS.Handlers.BrandHandlers;
using CarBook.Application.Features.CQRS.Queries.BrandQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BrandController : ControllerBase
	{
		private readonly GetBrandQueryHandler _handler;
		private readonly GetBrandByIdQueryHandler _handlerById;
		private readonly CreateBrandCommandHandler _createBrand;
		private readonly UpdateBrandCommandHandler _updateBrand;
		private readonly RemoveBrandCommandHandler _removeBrand;

		public BrandController(GetBrandQueryHandler handler, GetBrandByIdQueryHandler handlerById, CreateBrandCommandHandler createBrand, UpdateBrandCommandHandler updateBrand, RemoveBrandCommandHandler removeBrand)
		{
			_handler = handler;
			_handlerById = handlerById;
			_createBrand = createBrand;
			_updateBrand = updateBrand;
			_removeBrand = removeBrand;
		}

		[HttpGet]
		public async Task<IActionResult> BrandList()
		{
			var values = await _handler.Handle();
			return Ok(values);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetBrand(int id)
		{
			var value = await _handlerById.Handle(new GetBrandByIdQuery(id));
			return Ok(value);
		}
		[HttpPost]
		public async Task<IActionResult> CreateBrand(CreateBrandCommand command)
		{
			await _createBrand.Handle(command);
			return Ok("Brand oluşturuldu.");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateBrand(UpdateBrandCommand command)
		{
			await _updateBrand.Handle(command);
			return Ok("Brand güncellendi.");
		}
		[HttpDelete]
		public async Task<IActionResult> RemoveBrand(int id)
		{
			await _removeBrand.Handle(new RemoveBrandCommand(id));
			return Ok("Brand silindi.");
		}
	}
}
