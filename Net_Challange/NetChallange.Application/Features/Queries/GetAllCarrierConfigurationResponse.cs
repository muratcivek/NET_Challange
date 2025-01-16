using NetChallange.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetChallange.Application.Features.Queries;

public class GetAllCarrierConfigurationResponse
{
    public int Id { get; set; }

    public int CarrierId { get; set; }

    public int CarrierMaxDesi { get; set; }

    public int CarrierMinDesi { get; set; }

    public decimal CarrierCost { get; set; }

}
