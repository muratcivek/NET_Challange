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

public class CreateCarrierCommand:IRequest<CreateCarrierResponse>
{

    public string CarrierName { get; set; }

    public bool CarrierIsActive { get; set; }

    public int CarrierPlusDesiCost { get; set; }

    public int CarrierConfigurationId { get; set; }

    public class CreateCarrierCommandHandler : IRequestHandler<CreateCarrierCommand, CreateCarrierResponse>
    {
        private readonly IRepository<Carriers> _repository;
        public CreateCarrierCommandHandler(IRepository<Carriers> repository)
        {
            _repository = repository;
        }

        public async Task<CreateCarrierResponse> Handle(CreateCarrierCommand request, CancellationToken cancellationToken)
        {
            await _repository.InsertAsync(new Carriers
            {
                CarrierName = request.CarrierName,
                CarrierIsActive= request.CarrierIsActive,
                CarrierPlusDesiCost = request.CarrierPlusDesiCost,
                CarrierConfigurationId = request.CarrierConfigurationId
            });
            return new CreateCarrierResponse
            {
                Message = "Kargo firması başarıyla eklendi",     
            };
        }
    }
}
