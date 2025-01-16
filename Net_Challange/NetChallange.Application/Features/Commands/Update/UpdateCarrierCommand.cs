using MediatR;
using NetChallange.Application.Features.Commands.Create;
using NetChallange.Core.Entities;
using NetChallange.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetChallange.Application.Features.Commands.Update;

public class UpdateCarrierCommand : IRequest<UpdateCarrierResponse>
{
    public int Id { get; set; }

    public string CarrierName { get; set; }

    public bool CarrierIsActive { get; set; }

    public int CarrierPlusDesiCost { get; set; }

    public int CarrierConfigurationId { get; set; }

    public class UpdateCarrierCommandHandler : IRequestHandler<UpdateCarrierCommand, UpdateCarrierResponse>
    {
        private readonly IRepository<Carriers> _repository;
        public UpdateCarrierCommandHandler(IRepository<Carriers> repository)
        {
            _repository = repository;
        }
        public async Task<UpdateCarrierResponse> Handle(UpdateCarrierCommand request, CancellationToken cancellationToken)
        {
            await _repository.UpdateAsync(new Carriers
            {
                Id = request.Id,
                CarrierName = request.CarrierName,
                CarrierIsActive = request.CarrierIsActive,
                CarrierPlusDesiCost = request.CarrierPlusDesiCost,
                CarrierConfigurationId = request.CarrierConfigurationId
            });

            return new UpdateCarrierResponse
            {
                Message = "Kargo firması başarıyla güncellendi",     
            };
        }
    }
}
