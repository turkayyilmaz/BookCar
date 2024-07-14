﻿using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces.BlogInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers
{
	public class GetLast3BlogsWithAuthorsQueryHandler : IRequestHandler<GetLast3BlogsWithAuthorsQuery, List<GetLast3BlogsWithAuthorsQueryResult>>
	{
		private readonly IBlogRepository _blogRepository;
		public GetLast3BlogsWithAuthorsQueryHandler(IBlogRepository blogRepository)
		{
			_blogRepository = blogRepository;
		}
		public async Task<List<GetLast3BlogsWithAuthorsQueryResult>> Handle(GetLast3BlogsWithAuthorsQuery request, CancellationToken cancellationToken)
		{
			var values = _blogRepository.GetLast3BlogsWithAuthors();
			return values.Select(x => new GetLast3BlogsWithAuthorsQueryResult
			{
				AuthorId = x.AuthorId,
				BlogId = x.BlogId,
				CategoryId = x.CategoryId,
				CoverImageUrl = x.CoverImageUrl,
				CreatedDate = x.CreatedDate,
				Title = x.Title,
				AuthorName = x.Author.Name
			}).ToList();
		}
	}
}
