using CarBook.Application.Features.CQRS.Commands.CategoryCommands;
using CarBook.Application.Features.CQRS.Commands.ContactCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.ContactHandlers
{
	public class UpdateContactCommandHandler
	{
		private readonly IRepository<Contact> _repository;
		public UpdateContactCommandHandler(IRepository<Contact> repository)
		{
			_repository = repository;
		}
		public async Task Handle(UpdateContactCommand command)
		{
			var value = await _repository.GetByIdAsync(command.ContactID);
			value.ContactID = command.ContactID;
			value.Subject = command.Subject;
			value.Message = command.Message;
			value.Name = command.Name;
			value.Email = command.Email;
			value.SendDate = command.SendDate;
			await _repository.UpdateAsync(value);
		}
	}
}
