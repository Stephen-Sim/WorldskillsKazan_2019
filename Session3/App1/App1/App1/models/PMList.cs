using System;
using System.Collections.Generic;
using System.Text;

namespace App1.models
{
    public class PMList
    {
        public long ID { get; set; }
        public long AssetID { get; set; }
        public string AssetName { get; set; }
        public string AssetSN { get; set; }
        public long TaskID { get; set; }
        public string TaskName { get; set; }
        public string TaskDesc { get; set; }
        public long PMScheduleTypeID { get; set; }
        public Nullable<System.DateTime> ScheduleDate { get; set; }
        public Nullable<long> ScheduleKilometer { get; set; }
        public Nullable<bool> TaskDone { get; set; }
        public string Color { get; set; }

    }
}
