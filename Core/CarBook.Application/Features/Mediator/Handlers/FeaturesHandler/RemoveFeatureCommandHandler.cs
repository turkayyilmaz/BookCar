using CarBook.Application.Features.Mediator.Commands.FeaturesCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.FeaturesHandler
{
	public class RemoveFeatureCommandHandler : IRequestHandler<RemoveFeatureCommand>
	{
		private readonly IRepository<Feature> _repository;
		public RemoveFeatureCommandHandler(IRepository<Feature> repository)
		{
			_repository = repository;
		}
		public async Task Handle(RemoveFeatureCommand request, CancellationToken cancellationToken)
		{
			var value = await _repository.GetByIdAsync(request.Id);
			await _repository.RemoveAsync(value);
		}
	}
}
