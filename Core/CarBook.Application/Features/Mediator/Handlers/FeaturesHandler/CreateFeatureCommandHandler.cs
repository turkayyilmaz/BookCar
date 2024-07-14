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
	public class CreateFeatureCommandHandler : IRequestHandler<CreateFeatureCommand>
	{
		private readonly IRepository<Feature> _repository;
		public CreateFeatureCommandHandler(IRepository<Feature> repository)
		{
			_repository = repository;
		}
		public async Task Handle(CreateFeatureCommand request, CancellationToken cancellationToken)
		{
			await _repository.CreateAsync(new Feature
			{
				Name = request.Name,
			});
		}
	}
}
