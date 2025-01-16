using NetChallange.Application.Interface;
using NetChallange.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetChallange.Application.Services;

public class CreateOrderCalculationService : ICreateOrderCalculationService
{
    public (bool FoundMatchingConfiguration, decimal CarrierCost, int CarrierId) CalculateBestCarrier(int orderDesi, IEnumerable<Carriers> carriers, IEnumerable<CarrierConfigurations> configurations)
    {

        bool foundMatchingConfiguration = false;
        decimal carrierCost = decimal.MaxValue;
        int carrierId = 0;

        foreach (var carrier in carriers)
        {
            if (carrier.CarrierIsActive)
            {
                foreach (var configuration in configurations)
                {
                    if (configuration.CarrierId == carrier.Id &&
                        orderDesi >= configuration.CarrierMinDesi &&
                        orderDesi <= configuration.CarrierMaxDesi)
                    {
                        foundMatchingConfiguration = true;

                        if (configuration.CarrierCost < carrierCost)
                        {
                            carrierCost = configuration.CarrierCost;
                            carrierId = carrier.Id;
                        }
                    }
                }
            }
        }

        if (!foundMatchingConfiguration)
        {
            int plusDesiCost = 0;
            decimal closestDesiDifference = decimal.MaxValue;

            foreach (var configuration in configurations)
            {
                var desiDifference = Math.Abs(orderDesi - configuration.CarrierMaxDesi);

                if (desiDifference < closestDesiDifference)
                {
                    closestDesiDifference = desiDifference;

                    var carrier = carriers.FirstOrDefault(c => c.Id == configuration.CarrierId && c.CarrierIsActive);
                    if (carrier != null)
                    {
                        plusDesiCost = carrier.CarrierPlusDesiCost;
                        carrierId = carrier.Id;
                    }

                    carrierCost = configuration.CarrierCost + (plusDesiCost * closestDesiDifference);
                }
            }
        }

        return (foundMatchingConfiguration, carrierCost, carrierId);
    }
}
