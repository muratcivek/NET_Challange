using MediatR;
using NetChallange.Core.Entities;
using NetChallange.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NetChallange.Application.Features.Commands.Create;

public class CreateCarrierConfigurationCommand : IRequest<CreateCarrierConfigurationResponse>
{

    public int CarrierId { get; set; }

    public int CarrierMaxDesi { get; set; }

    public int CarrierMinDesi { get; set; }

    public decimal CarrierCost { get; set; }


    public class CreateCarrierConfigurationCommandHandler : IRequestHandler<CreateCarrierConfigurationCommand, CreateCarrierConfigurationResponse>
    {
        private readonly IRepository<CarrierConfigurations> _repository;
        public CreateCarrierConfigurationCommandHandler(IRepository<CarrierConfigurations> repository)
        {
            _repository = repository;
        }

        public async Task<CreateCarrierConfigurationResponse> Handle(CreateCarrierConfigurationCommand request, CancellationToken cancellationToken)
        {
            await _repository.InsertAsync(new CarrierConfigurations
            {   
                CarrierId = request.CarrierId,
                CarrierMaxDesi = request.CarrierMaxDesi,
                CarrierMinDesi = request.CarrierMinDesi,
                CarrierCost = request.CarrierCost
            });
            return new CreateCarrierConfigurationResponse
            {
                Message = "Kargo firması konfigürasyonu başarıyla eklendi",    
            };
        }
    }
}
