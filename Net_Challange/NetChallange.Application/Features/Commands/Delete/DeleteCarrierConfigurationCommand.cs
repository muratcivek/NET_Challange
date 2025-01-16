using MediatR;
using NetChallange.Application.Features.Commands.Create;
using NetChallange.Core.Entities;
using NetChallange.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetChallange.Application.Features.Commands.Delete;

public class DeleteCarrierConfigurationCommand: IRequest<DeleteCarrierConfigurationResponse>
{
    public int Id { get; set; }
    public class DeleteCarrierConfigurationCommandHandler : IRequestHandler<DeleteCarrierConfigurationCommand, DeleteCarrierConfigurationResponse>
    {
        private readonly IRepository<CarrierConfigurations> _repository;
        public DeleteCarrierConfigurationCommandHandler(IRepository<CarrierConfigurations> repository)
        {
            _repository = repository;
        }
        public async Task<DeleteCarrierConfigurationResponse> Handle(DeleteCarrierConfigurationCommand request, CancellationToken cancellationToken)
        {
            CarrierConfigurations? carrierConfigurations = await _repository.GetByIdAsync(request.Id);

            if (carrierConfigurations != null)
            {

                await _repository.DeleteAsync(request.Id);
            }

            return new DeleteCarrierConfigurationResponse
            {
                Id = request.Id,
                Message = "Kargo firma ayarları başarıyla silindi",     
            };
        }
    }
}
