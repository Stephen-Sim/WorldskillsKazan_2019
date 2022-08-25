using System;
using System.Collections.Generic;
using System.Text;

namespace App1.models
{
    public class AssetRequest
    {
        public long DepartmentId { get; set; } = 0;
        public long AssetGroupId { get; set; } = 0;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string SearchContent { get; set; }
    }
}
