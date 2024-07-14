using CarBook.Application.Features.CQRS.Queries.BrandQueries;
using CarBook.Application.Features.CQRS.Queries.CarQueries;
using CarBook.Application.Features.CQRS.Results.BrandResults;
using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
	public class GetCarByIdQueryHandler
	{
		private readonly IRepository<Car> _repository;
		public GetCarByIdQueryHandler(IRepository<Car> repository)
		{
			_repository = repository;
		}
		public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery query)
		{
			var value = await _repository.GetByIdAsync(query.Id);
			return new GetCarByIdQueryResult
			{
				CarID = value.CarID,
				BrandID = value.BrandID,
				BigImageUrl = value.BigImageUrl,
				CoverImageUrl = value.CoverImageUrl,
				Fuel = value.Fuel,
				Km = value.Km,
				Luggage = value.Luggage,
				Model = value.Model,
				Seat = value.Seat,
				Transmission = value.Transmission
			};
		}
	}
}
