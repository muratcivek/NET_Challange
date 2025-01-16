using MediatR;
using NetChallange.Application.Interface;
using NetChallange.Core.Entities;
using NetChallange.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NetChallange.Application.Features.Commands.Create;

public class CreateOrderCommand:IRequest<CreateOrderResponse>
{
    public int OrderDesi { get; set; }

    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CreateOrderResponse>
    {
        private readonly IRepository<Orders> _repositoryOrders;
        private readonly IRepository<Carriers> _repositoryCarriers;
        private readonly IRepository<CarrierConfigurations> _repositoryCarrierConfigurations;
        private readonly ICreateOrderCalculationService _createOrderCalculationService;

        public CreateOrderCommandHandler(
            IRepository<Orders> repositoryOrders,
            IRepository<Carriers> repositoryCarriers,
            IRepository<CarrierConfigurations> repositoryCarrierConfigurations,
            ICreateOrderCalculationService createOrderCalculationService)
        {
            _repositoryOrders = repositoryOrders;
            _repositoryCarriers = repositoryCarriers;
            _repositoryCarrierConfigurations = repositoryCarrierConfigurations;
            _createOrderCalculationService = createOrderCalculationService;
        }

        public async Task<CreateOrderResponse> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            int orderDesi = request.OrderDesi;

            var carriers = await _repositoryCarriers.GetAllAsync();
            var carrierConfigurations = await _repositoryCarrierConfigurations.GetAllAsync();

            var result = _createOrderCalculationService.CalculateBestCarrier(orderDesi, carriers, carrierConfigurations);

            await _repositoryOrders.InsertAsync(new Orders
            {
                OrderDesi = orderDesi,
                OrderDate = DateTime.Now,
                OrderCarrierCost = result.CarrierCost,
                CarrierId = result.CarrierId
            });

            return new CreateOrderResponse
            {
                Message = "Sipariş başarıyla eklendi"
            };
        }
    }

}
