using CarBook.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarBook.Domain.Entites;
using CarBook.Application.Features.CQRS.Results.AboutResults;
namespace CarBook.Application.Features.CQRS.Handlers.AboutHandlers
{
	public class GetAboutQueryHandler
	{
		private readonly IRepository<About> _repository;

		public GetAboutQueryHandler(IRepository<About> repository)
		{
			_repository = repository;
		}
		public async Task<List<GetAboutQueryResult>> Handle()
		{
			//about clasındaki propları _repository ile alıyoruz ve GetAboutQueryResult'dan nesne oluşturup aynı proplara atıyoruz
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetAboutQueryResult
			{
				AboutID = x.AboutID,
				Description = x.Description,
				Title = x.Title,
				ImageUrl = x.ImageUrl,
			}).ToList();
		}
	}
}
