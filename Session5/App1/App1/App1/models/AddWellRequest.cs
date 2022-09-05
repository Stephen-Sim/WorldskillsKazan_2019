using System;
using System.Collections.Generic;
using System.Text;

namespace App1.models
{
    public class AddWellRequest
    {
        public string WellName { get; set; }
        public long WellID { get; set; }
        public long WellTypeID { get; set; }
        public long GasOilDepth { get; set; }
        public long Capacity { get; set; }
        public List<RockLayer> RockLayers { get; set; }
    }
}
