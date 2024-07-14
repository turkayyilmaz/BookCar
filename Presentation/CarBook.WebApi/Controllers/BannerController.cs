using CarBook.Application.Features.CQRS.Commands.BannerCommands;
using CarBook.Application.Features.CQRS.Handlers.BannerHandlers;
using CarBook.Application.Features.CQRS.Queries.BannerQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BannerController : ControllerBase
	{
		private readonly GetBannerQueryHandler _getBanner;
		private readonly GetBannerByIdQueryHandler _getBannerById;
		private readonly CreateBannerCommandHandler _createBanner;
		private readonly UpdateBannerCommandHandler _updateBanner;
		private readonly RemoveBannerCommandHandler _removeBanner;

		public BannerController(GetBannerQueryHandler getBanner, GetBannerByIdQueryHandler getBannerById, CreateBannerCommandHandler createBanner, UpdateBannerCommandHandler updateBanner, RemoveBannerCommandHandler removeBanner)
		{
			_getBanner = getBanner;
			_getBannerById = getBannerById;
			_createBanner = createBanner;
			_updateBanner = updateBanner;
			_removeBanner = removeBanner;
		}
		[HttpGet]
		public async Task<IActionResult> BannerList()
		{
			var values = await _getBanner.Handle();
			return Ok(values);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetBanner(int id)
		{
			var value = await _getBannerById.Handle(new GetBannerByIdQuery(id));
			return Ok(value);
		}
		[HttpPost]
		public async Task<IActionResult> CreateBanner(CreateBannerCommand command)
		{
			await _createBanner.Handle(command);
			return Ok("Banner oluşturuldu.");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateBanner(UpdateBannerCommand command)
		{
			await _updateBanner.Handle(command);
			return Ok("Banner güncellendi.");
		}
		[HttpDelete]
		public async Task<IActionResult> RemoveBanner(int id)
		{
			await _removeBanner.Handle(new RemoveBannerCommand(id));
			return Ok("Banner silindi.");
		}
	}
}
