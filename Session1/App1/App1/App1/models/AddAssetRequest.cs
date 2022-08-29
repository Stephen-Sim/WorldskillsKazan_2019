using System;
using System.Collections.Generic;
using System.Text;

namespace App1.models
{
    public class AddAssetRequest
    {
        public Nullable<long> AssetID { get; set; }
        public string AssetName { get; set; }
        public string AssetDesc { get; set; }
        public long DepartmentId { get; set; }
        public long LocationId { get; set; }
        public long AssetGroupId { get; set; }
        public long EmployeeId { get; set; }
        public DateTime ExpiredDate { get; set; }
    }
}
