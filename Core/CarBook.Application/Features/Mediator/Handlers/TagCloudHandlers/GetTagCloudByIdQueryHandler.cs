﻿using CarBook.Application.Features.Mediator.Queries.TagCloudsQueries;	
using CarBook.Application.Features.Mediator.Queries.TagCloudsQueries;
using CarBook.Application.Features.Mediator.Results.TagCloudResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.TagCloudHandlers
{
	public class GetTagCloudByIdQueryHandler : IRequestHandler<GetTagCloudByIdQuery, GetTagCloudByIdQueryResult>
	{
		private readonly IRepository<TagCloud> _repository;
		public GetTagCloudByIdQueryHandler(IRepository<TagCloud> repository)
		{
			_repository = repository;
		}
		public async Task<GetTagCloudByIdQueryResult> Handle(GetTagCloudByIdQuery request, CancellationToken cancellationToken)
		{
			var value = await _repository.GetByIdAsync(request.Id);
			return new GetTagCloudByIdQueryResult
			{
				TagCloudId = value.TagCloudId,
				Title = value.Title,
				BlogId = value.BlogId,
			};
		}
	}
}
