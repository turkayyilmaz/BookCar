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
	public class UpdateFeatureCommandHandler : IRequestHandler<UpdateFeatureCommand>
	{
		private readonly IRepository<Feature> _repository;
		public UpdateFeatureCommandHandler(IRepository<Feature> repository)
		{
			_repository = repository;
		}
		public async Task Handle(UpdateFeatureCommand request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.FeatureID);
			values.Name = request.Name;
			await _repository.UpdateAsync(values);
		}
	}
}
