using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetChallange.Application.Features.Queries;

public class GetAllCarriersResponse
{
    public int Id { get; set; }

    public string CarrierName { get; set; }

    public bool CarrierIsActive { get; set; }

    public int CarrierPlusDesiCost { get; set; }

    public int CarrierConfigurationId { get; set; }
}
