﻿using CarBook.Application.Features.Mediator.Commands.LocationCommands;
using CarBook.Application.Features.Mediator.Commands.TagCloudCommands;
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
	public class UpdateTagCloudCommandHandler : IRequestHandler<UpdateTagCloudCommand>
	{
		private readonly IRepository<TagCloud> _repository;
		public UpdateTagCloudCommandHandler(IRepository<TagCloud> repository)
		{
			_repository = repository;
		}
		public async Task Handle(UpdateTagCloudCommand request, CancellationToken cancellationToken)
		{
			var value = await _repository.GetByIdAsync(request.TagCloudId);
			value.Title = request.Title;
			value.BlogId = request.BlogId;
			await _repository.UpdateAsync(value);
		}
	}
}
