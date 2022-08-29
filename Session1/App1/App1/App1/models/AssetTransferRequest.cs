using System;
using System.Collections.Generic;
using System.Text;

namespace App1.models
{
    public class AssetTransferRequest
    {
        public long AssetID { get; set; }
        public long NewDepartmentId { get; set; }
        public long NewLocationId { get; set; }
        public long AssetGroupId { get; set; }
    }
}
