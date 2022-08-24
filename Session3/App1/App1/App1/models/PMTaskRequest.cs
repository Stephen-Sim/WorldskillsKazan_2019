using System;
using System.Collections.Generic;
using System.Text;

namespace App1.models
{
    public class PMTaskRequest
    {
        public long TaskId { get; set; }
        public List<long> AssetId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Nullable<int> DayIntervalToRun { get; set; }
        public Nullable<DayOfWeek> DayofWeektoRun { get; set; }
        public Nullable<int> NumbersofWeekstoRun { get; set; }
        public Nullable<int> DayofMonthtoRun { get; set; }
        public Nullable<int> NumberofMonthstoRun { get; set; }

    }
}
