using MediatR;
using NetChallange.Core.Entities;
using NetChallange.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NetChallange.Application.Features.Queries;

public class GetAllCarrierConfigurationQuery : IRequest<List<GetAllCarrierConfigurationResponse>>
{
}

public class GetAllCarrierConfigurationQueryHandler : IRequestHandler<GetAllCarrierConfigurationQuery, List<GetAllCarrierConfigurationResponse>>
{
    private readonly IRepository<CarrierConfigurations> _repository;

    public GetAllCarrierConfigurationQueryHandler(IRepository<CarrierConfigurations> repository)
    {
        _repository = repository;
    }

    public async Task<List<GetAllCarrierConfigurationResponse>> Handle(GetAllCarrierConfigurationQuery request, CancellationToken cancellationToken)
    {
       
            var carrierConfigurations = await _repository.GetAllAsync();

            var response = carrierConfigurations.Select(carrierConfigurations => new GetAllCarrierConfigurationResponse
            {
                Id = carrierConfigurations.Id,
                CarrierId = carrierConfigurations.CarrierId,
                CarrierMaxDesi = carrierConfigurations.CarrierMaxDesi,
                CarrierMinDesi = carrierConfigurations.CarrierMinDesi,
                CarrierCost = carrierConfigurations.CarrierCost
            }).ToList();

            return response;
        
      
    }
}
