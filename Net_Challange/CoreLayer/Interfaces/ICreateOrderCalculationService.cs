using NetChallange.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetChallange.Application.Interface;

public interface ICreateOrderCalculationService
{
    (bool FoundMatchingConfiguration, decimal CarrierCost, int CarrierId) CalculateBestCarrier(int orderDesi, IEnumerable<Carriers> carriers, IEnumerable<CarrierConfigurations> configurations);

}
