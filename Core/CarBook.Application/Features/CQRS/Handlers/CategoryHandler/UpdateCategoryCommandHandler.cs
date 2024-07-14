using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.Features.CQRS.Commands.CategoryCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CategoryHandler
{
	public class UpdateCategoryCommandHandler
	{
		private readonly IRepository<Category> _repository;
		public UpdateCategoryCommandHandler(IRepository<Category> repository)
		{
			_repository = repository;
		}
		public async Task Handle(UpdateCategoryCommand command)
		{
			var value = await _repository.GetByIdAsync(command.CategoryID);
			value.CategoryID = command.CategoryID;
			value.Name = command.Name;
			await _repository.UpdateAsync(value);
		}
	}
}
