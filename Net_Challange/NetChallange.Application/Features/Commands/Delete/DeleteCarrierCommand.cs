using MediatR;
using NetChallange.Application.Features.Commands.Update;
using NetChallange.Core.Entities;
using NetChallange.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetChallange.Application.Features.Commands.Delete;

public class DeleteCarrierCommand:IRequest<DeleteCarrierResponse>
{
    public int Id { get; set; }

    public class DeleteCarrierCommandHandler : IRequestHandler<DeleteCarrierCommand, DeleteCarrierResponse>
    {
        private readonly IRepository<Carriers> _repository;
        public DeleteCarrierCommandHandler(IRepository<Carriers> repository)
        {
            _repository = repository;
        }
        public async Task<DeleteCarrierResponse> Handle(DeleteCarrierCommand request, CancellationToken cancellationToken)
        {
            Carriers? carriers = await _repository.GetByIdAsync(request.Id);

           if(carriers != null){

                await _repository.DeleteAsync(request.Id);
            }

            return new DeleteCarrierResponse
            {
                Id = request.Id,
                Message = "Kargo firması başarıyla silindi",    
            };
        }
    }
}
