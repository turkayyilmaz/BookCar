using CarBook.Application.Features.CQRS.Results.AboutResults;
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
	public class GetFooterAdressByIdQueryHandler : IRequestHandler<GetFooterAdressByIdQuery, GetFooterAdressByIdQueryResult>
	{
		private readonly IRepository<FooterAddress> _repository;
		public GetFooterAdressByIdQueryHandler(IRepository<FooterAddress> repository)
		{
			_repository = repository;
		}
		public async Task<GetFooterAdressByIdQueryResult> Handle(GetFooterAdressByIdQuery request, CancellationToken cancellationToken)
		{
			var value = await _repository.GetByIdAsync(request.Id);
			return new GetFooterAdressByIdQueryResult { 
				Address = value.Address,
				Description = value.Description,
				Email = value.Email,
				FooterAddressID = value.FooterAddressID,
				Phone = value.Phone
			};
		}
	}
}
