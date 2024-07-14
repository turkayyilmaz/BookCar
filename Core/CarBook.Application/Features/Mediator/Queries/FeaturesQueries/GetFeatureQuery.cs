using CarBook.Application.Features.Mediator.Results.FeaturesResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.FeaturesQueries
{
	public class GetFeatureQuery : IRequest<List<GetFeatureQueryResult>>
	{
        
	}
}
