using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NetChallange.Core.Entities;

public class Orders:BaseEntity
{
    public int OrderDesi { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal OrderCarrierCost { get; set; }
    public int CarrierId { get; set; }
    public Carriers Carriers { get; set; }

}
