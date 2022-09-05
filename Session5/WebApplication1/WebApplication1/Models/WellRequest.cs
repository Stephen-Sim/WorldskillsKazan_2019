using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class WellRequest
    {
        public string WellName { get; set; }
        public long WellID { get; set; }
        public long WellTypeID { get; set; }
        public long GasOilDepth { get; set; }
        public long Capacity { get; set; }
        public List<RockLayer> RockLayers { get; set; }
        public class RockLayer
        {
            public long RockId { get; set; }
            public string RockName { get; set; }
            public long FromDepth { get; set; }
            public long ToDepth { get; set; }

            public string FromToDepth
            {
                get { return $"From : {FromDepth} to {ToDepth}"; }
                set { }
            }
        }
    }
}