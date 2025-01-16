﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetChallange.Application.Features.Queries;

public class GetAllOrdersResponse
{
    public int Id { get; set; }
    public int OrderDesi { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal OrderCarrierCost { get; set; }
    public int CarrierId { get; set; }
}
