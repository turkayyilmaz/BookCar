using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers
{
	public class GetBlogByIdQueryHandler : IRequestHandler<GetBlogQueryById, GetBlogByIdQueryResult>
	{
		private readonly IRepository<Blog> _repository;
		public GetBlogByIdQueryHandler(IRepository<Blog> repository)
		{
			_repository = repository;
		}
		public async Task<GetBlogByIdQueryResult> Handle(GetBlogQueryById request, CancellationToken cancellationToken)
		{
			var value = await _repository.GetByIdAsync(request.Id);
			return new GetBlogByIdQueryResult
			{
				BlogId = value.BlogId,
				Title = value.Title,
				AuthorId = value.AuthorId,
				CategoryId = value.CategoryId,
				CoverImageUrl = value.CoverImageUrl,
				CreatedDate	= value.CreatedDate,
				Description = value.Description,
			};
		}
	}
}
