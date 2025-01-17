using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetChallange.Core.Entities;

public class Carriers:BaseEntity
{
    public string CarrierName { get; set; }

    public bool CarrierIsActive { get; set; }

    public int CarrierPlusDesiCost { get; set; }

    public int CarrierConfigurationId { get; set; }
    public ICollection<Orders> Orders { get; set; }
    public CarrierConfigurations CarrierConfigurations { get; set; }


}
