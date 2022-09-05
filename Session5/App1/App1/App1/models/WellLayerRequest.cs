using System;
using System.Collections.Generic;
using System.Text;

namespace App1.models
{
    public class WellLayerRequest
    {
        public string Name { get; set; }
        public string BackgroundColor { get; set; }
        public long StartPoint { get; set; }
        public long EndPoint { get; set; }
        public string TextColor { get; set; }
        public long Depth { get; set; }

    }
}
