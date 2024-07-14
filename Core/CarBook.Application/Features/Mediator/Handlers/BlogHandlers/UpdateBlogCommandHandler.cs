using CarBook.Application.Features.Mediator.Commands.BlogCommands;
using CarBook.Application.Features.Mediator.Commands.LocationCommands;
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
	public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand>
	{
		private readonly IRepository<Blog> _repository;
		public UpdateBlogCommandHandler(IRepository<Blog> repository)
		{
			_repository = repository;
		}
		public async Task Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
		{
			var value = await _repository.GetByIdAsync(request.BlogId);
			value.AuthorId = request.AuthorId;
			value.CreatedDate = request.CreatedDate;
			value.CategoryId = request.CategoryId;
			value.CoverImageUrl = request.CoverImageUrl;
			value.Title = request.Title;
			value.Description = request.Description;
			await _repository.UpdateAsync(value);
		}
	}
}
