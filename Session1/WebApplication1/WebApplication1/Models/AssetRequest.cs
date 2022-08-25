using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class AssetRequest
    {
        public long DepartmentId { get; set; }
        public long AssetGroupId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string SearchContent { get; set; }
    }
}