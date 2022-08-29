using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class AssetTransferRequest
    {
        public long AssetID { get; set; }
        public long NewDepartmentId { get; set; }
        public long NewLocationId { get; set; }
        public long AssetGroupId { get; set; }
    }
}