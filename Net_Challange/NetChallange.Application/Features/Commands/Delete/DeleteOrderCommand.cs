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

public class DeleteOrderCommand : IRequest<DeleteOrderResponse>
{
    public int Id { get; set; }

    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, DeleteOrderResponse>
    {
        private readonly IRepository<Orders> _repository;
        public DeleteOrderCommandHandler(IRepository<Orders> repository)
        {
            _repository = repository;
        }
        public async Task<DeleteOrderResponse> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            Orders? Orders = await _repository.GetByIdAsync(request.Id);

            if (Orders != null)
            {

                await _repository.DeleteAsync(request.Id);
            }

            return new DeleteOrderResponse
            {
                Id = request.Id,
                Message = "Sipariş başarıyla silindi",     
            };
        }
    }
}
