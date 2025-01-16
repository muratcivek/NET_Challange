using MediatR;
using NetChallange.Application.Features.Commands.Update;
using NetChallange.Core.Entities;
using NetChallange.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetChallange.Application.Features.Queries;

public class GetAllCarriersQuery : IRequest<List<GetAllCarriersResponse>> 
{

    public class GetAllCarriersQueryHandler : IRequestHandler<GetAllCarriersQuery, List<GetAllCarriersResponse>>
    {
        private readonly IRepository<Carriers> _repository;

        public GetAllCarriersQueryHandler(IRepository<Carriers> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAllCarriersResponse>> Handle(GetAllCarriersQuery request, CancellationToken cancellationToken)
        {
            var carriers = await _repository.GetAllAsync();

            var response = carriers.Select(carrier => new GetAllCarriersResponse
            {
                Id = carrier.Id,
                CarrierName = carrier.CarrierName,
                CarrierIsActive = carrier.CarrierIsActive,
                CarrierPlusDesiCost = carrier.CarrierPlusDesiCost,
                CarrierConfigurationId = carrier.CarrierConfigurationId
            }).ToList();

            return response;
        }
    }
}
