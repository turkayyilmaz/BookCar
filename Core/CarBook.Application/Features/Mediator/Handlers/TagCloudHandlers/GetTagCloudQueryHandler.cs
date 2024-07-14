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
	public class GetTagCloudQueryHandler : IRequestHandler<GetTagCloudQuery, List<GetTagCloudQueryResult>>
	{
		private readonly IRepository<TagCloud> _repository;
		public GetTagCloudQueryHandler(IRepository<TagCloud> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetTagCloudQueryResult>> Handle(GetTagCloudQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetTagCloudQueryResult
			{
				TagCloudId = x.TagCloudId,
				Title = x.Title,
				BlogId = x.BlogId,
			}).ToList();
		}
	}
}
