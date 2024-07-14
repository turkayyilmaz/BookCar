using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.Features.CQRS.Handlers.CarHandlers;
using CarBook.Application.Features.CQRS.Queries.CarQueries;
using CarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CarController : ControllerBase
	{
		private readonly GetCarQueryHandler _handler;
		private readonly GetCarByIdQueryHandler _handlerById;
		private readonly CreateCarCommandHandler _create;
		private readonly UpdateCarCommandHandler _update;
		private readonly RemoveCarCommandHandler _remove;
		private readonly GetCarWithBrandQueryHandler _carwithbrand;
		private readonly GetLast5CarsWithBrandHandler _last5;
		private readonly IMediator _mediator;

		public CarController(GetCarWithBrandQueryHandler carwithbrand, GetCarQueryHandler handler, GetCarByIdQueryHandler handlerById, CreateCarCommandHandler create, UpdateCarCommandHandler update, RemoveCarCommandHandler remove, GetLast5CarsWithBrandHandler last5, IMediator mediator)
		{
			_handler = handler;
			_handlerById = handlerById;
			_create = create;
			_update = update;
			_remove = remove;
			_carwithbrand = carwithbrand;
			_last5 = last5;
			_mediator = mediator;
		}
		[HttpGet]
		public async Task<IActionResult> CarList()
		{
			var values = await _handler.Handle();
			return Ok(values);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetCar(int id)
		{
			var value = await _handlerById.Handle(new GetCarByIdQuery(id));
			return Ok(value);
		}
		[HttpPost]
		public async Task<IActionResult> CreateCar(CreateCarCommand command)
		{
			await _create.Handle(command);
			return Ok("Car oluşturuldu.");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateCar(UpdateCarCommand command)
		{
			await _update.Handle(command);
			return Ok("Car güncellendi.");
		}
		[HttpDelete("{id}")]
		public async Task<IActionResult> RemoveCar(int id)
		{
			await _remove.Handle(new RemoveCarCommand(id));
			return Ok("Car silindi.");
		}
		[HttpGet("GetCarWithBrand")]
		public IActionResult GetCarWithBrand()
		{
			var values =  _carwithbrand.Handle();
			return Ok(values);
		}
		[HttpGet("GetLast5CarsWithBrand")]
		public IActionResult GetLast5CarsWithBrand()
		{
			var values =  _last5.Handle();
			return Ok(values);
		}
        [HttpGet("GetCarCount")]
        public IActionResult GetCarCount()
        {
			var values = _mediator.Send(new GetCarCountQuery());
            return Ok(values);
        }
    }
}
