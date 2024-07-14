using CarBook.Application.Features.Mediator.Queries.TagCloudsQueries;
using CarBook.Application.Features.Mediator.Results.TagCloudResults;
using CarBook.Application.Interfaces.TagCloudInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.TagCloudHandlers
{
	public class GetTagCloudByBlogIdQueryHandler : IRequestHandler<GetTagCloudByBlogIdQuery, List<GetTagCloudByBlogIdQueryResult>>
	{
		private readonly ITagCloudRepository _tagCloudRepository;
		public GetTagCloudByBlogIdQueryHandler(ITagCloudRepository tagCloudRepository)
		{
			_tagCloudRepository = tagCloudRepository;
		}
		public async Task<List<GetTagCloudByBlogIdQueryResult>> Handle(GetTagCloudByBlogIdQuery request, CancellationToken cancellationToken)
		{
			var values = _tagCloudRepository.GetTagCloudsByBlogId(request.Id);
			return values.Select(x => new GetTagCloudByBlogIdQueryResult
			{
				Title = x.Title,
				TagCloudId = x.TagCloudId,
				BlogId = x.BlogId,
			}).ToList(); ;
		}
	}
}
