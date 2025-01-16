using MediatR;
using NetChallange.Core.Entities;
using NetChallange.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetChallange.Application.Features.Commands.Update;

public class UpdateCarrierConfigurationCommand:IRequest<UpdateCarrierConfigurationResponse>
{
    public int Id { get; set; }

    public int CarrierId { get; set; }

    public int CarrierMaxDesi { get; set; }

    public int CarrierMinDesi { get; set; }

    public decimal CarrierCost { get; set; }

    public class UpdateCarrierConfigurationCommandHandler : IRequestHandler<UpdateCarrierConfigurationCommand, UpdateCarrierConfigurationResponse>
    {
        private readonly IRepository<CarrierConfigurations> _repository;

        public UpdateCarrierConfigurationCommandHandler(IRepository<CarrierConfigurations> repository)
        {
            _repository = repository;
        }

        public async Task<UpdateCarrierConfigurationResponse> Handle(UpdateCarrierConfigurationCommand request, CancellationToken cancellationToken)
        {
            await _repository.UpdateAsync(new CarrierConfigurations
            {
                Id = request.Id,
                CarrierId = request.CarrierId,
                CarrierMaxDesi = request.CarrierMaxDesi,
                CarrierMinDesi = request.CarrierMinDesi,
                CarrierCost = request.CarrierCost
            });

            return new UpdateCarrierConfigurationResponse
            {
                Message = "Kargo firması ayarları başarıyla güncellendi",     
            };
        }
    }
}
