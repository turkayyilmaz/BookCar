using CarBook.Application.Features.Mediator.Commands.FooterAdressCommands;
using CarBook.Application.Features.Mediator.Queries.FooterAdressQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FooterAdressController : ControllerBase
	{
		private readonly IMediator _mediator;
		public FooterAdressController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpGet]
		public async Task<IActionResult> GetFooterAdressList()
		{
			var values = await _mediator.Send(new GetFooterAdressQuery());
			return Ok(values);
		}
		[HttpPost]
		public async Task<IActionResult> CreateFooterAdress(CreateFooterAdressCommand command)
		{
			await _mediator.Send(command);
			return Ok("Footer adres oluşturuldu.");
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetFooterAdressById(int id)
		{
			var value = await _mediator.Send(new GetFooterAdressByIdQuery(id));
			return Ok(value);
		}
		[HttpDelete]
		public async Task<IActionResult> DeleteFooterAdress(int id)
		{
			await _mediator.Send(new RemoveFooterAdressCommand(id));
			return Ok("Footer Adress silindi.");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateFooterAdress(UpdateFooterAdressCommand command)
		{
			await _mediator.Send(command);
			return Ok("Footer adress güncellendi.");
		}

	}
}
