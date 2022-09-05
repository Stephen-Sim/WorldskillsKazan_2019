using System;
using System.Collections.Generic;
using System.Text;

namespace App1.models
{
    public class RockLayer
    {
        public long RockId { get; set; }
        public string RockName { get; set; }
        public long FromDepth { get; set; }
        public long ToDepth { get; set; }

        public string FromToDepth { 
            get { return $"From : {FromDepth} to {ToDepth}"; }
            set { } 
        }
    }
}
