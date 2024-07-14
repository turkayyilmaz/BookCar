using CarBook.Application.Features.CQRS.Results.CategoryResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CategoryHandler
{
	public class GetContactyQueryHandler
	{
		private readonly IRepository<Category> _repository;
		public GetContactyQueryHandler(IRepository<Category> repository)
		{
			_repository = repository;
		}
		public async Task<List<GetCategoryQueryResult>> Handle()
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetCategoryQueryResult
			{
				CategoryID = x.CategoryID,
				Name = x.Name,
			}).ToList();
		}
	}
}
