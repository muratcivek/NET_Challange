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

public class GetAllOrdersQuery : IRequest<List<GetAllOrdersResponse>>
{

    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, List<GetAllOrdersResponse>>
    {
        private readonly IRepository<Orders> _repository;

        public GetAllOrdersQueryHandler(IRepository<Orders> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAllOrdersResponse>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var Orders = await _repository.GetAllAsync();

            var response = Orders.Select(carrier => new GetAllOrdersResponse
            {
                Id = carrier.Id,
                OrderDesi = carrier.OrderDesi,
                OrderDate = carrier.OrderDate,
                OrderCarrierCost = carrier.OrderCarrierCost,
                CarrierId = carrier.CarrierId
            }).ToList();

            return response;
        }
    }
}
