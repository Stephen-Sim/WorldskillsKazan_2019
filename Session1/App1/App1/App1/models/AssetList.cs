using System;
using System.Collections.Generic;
using System.Text;

namespace App1.models
{
    public class AssetList
    {
        public long AssetID { get; set; }
        public string AssetName { get; set; }
        public string AssetSN { get; set; }
        public string Location { get; set; }
        public string Department { get; set; }
        public long AssetGroupId { get; set; }
    }
}
