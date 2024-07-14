using CarBook.Application.Features.Mediator.Commands.SocialMediaCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.SocialMediaHandlers
{
	public class UdapteSocialMediaCommandHandler : IRequestHandler<UpdateSocialMediaCommand>
	{
		private readonly IRepository<SocialMedia> _repository;
		public UdapteSocialMediaCommandHandler(IRepository<SocialMedia> repository)
		{
			_repository = repository;
		}
		public async Task Handle(UpdateSocialMediaCommand request, CancellationToken cancellationToken)
		{
			var value = await _repository.GetByIdAsync(request.SocialMediaID);
			value.Url = request.Url;
			value.Icon = request.Icon;
			value.Name = request.Name;
			await _repository.UpdateAsync(value);
		}
	}
}
