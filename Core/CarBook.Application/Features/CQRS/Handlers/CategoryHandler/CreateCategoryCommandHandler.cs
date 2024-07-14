﻿using CarBook.Application.Features.CQRS.Commands.CarCommands;
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
	public class CreateCategoryCommandHandler
	{

		private readonly IRepository<Category> _repository;
		public CreateCategoryCommandHandler(IRepository<Category> repository)
		{
			_repository = repository;
		}
		public async Task Handle(CreateCategoryCommand command)
		{
			await _repository.CreateAsync(new Category
			{
				Name = command.Name
			});
		}
	}
}
