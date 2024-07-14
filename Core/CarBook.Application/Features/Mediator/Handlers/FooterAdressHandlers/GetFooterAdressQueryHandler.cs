using CarBook.Application.Features.Mediator.Queries.FooterAdressQueries;
using CarBook.Application.Features.Mediator.Results.FooterAdressResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.FooterAdressHandlers
{
	public class GetFooterAdressQueryHandler : IRequestHandler<GetFooterAdressQuery, List<GetFooterAdressQueryResult>>
	{
		private readonly IRepository<FooterAddress> _repository;
		public GetFooterAdressQueryHandler(IRepository<FooterAddress> repository)
		{
			_repository = repository;
		}
		public async Task<List<GetFooterAdressQueryResult>> Handle(GetFooterAdressQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetFooterAdressQueryResult
			{
				Address = x.Address,
				Description	= x.Description,
				Email = x.Email,
				FooterAddressID = x.FooterAddressID,
				Phone = x.Phone,
			}).ToList();
		}
	}
}
