using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.FeaturesCommands
{
	public class RemoveFeatureCommand : IRequest
	{
        public int Id { get; set; }
        public RemoveFeatureCommand(int id)
		{
			Id = id;
		}
	}
}
