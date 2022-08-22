using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class GetController : ApiController
    {
        WSC2019_Session3Entities ent = new WSC2019_Session3Entities();
        
        [HttpGet]
        public object GetActiveTask(string activeDate)
        {
            var ActiveDate = (activeDate == null) ? DateTime.Now : DateTime.ParseExact(activeDate, "yyyy-MM-dd", null);
            var ActiveDateAfter4days = ActiveDate.AddDays(4);

            var getPmList = ent.PMTasks
                .Where(x => x.ScheduleDate == null || x.ScheduleDate <= ActiveDateAfter4days)
                .OrderBy(x => x.PMScheduleTypeID).ThenBy(x => x.TaskDone).ToList().Select(x => new
                {
                    x.ID,
                    x.AssetID,
                    x.Asset.AssetName,
                    x.Asset.AssetSN,
                    x.TaskID,
                    TaskName = x.Task.Name,
                    x.PMScheduleTypeID,
                    x.ScheduleDate,
                    x.ScheduleKilometer,
                    TaskDesc = new Func<string>(() =>
                    {
                        if (x.PMScheduleTypeID == 1)
                        {
                            return $"Milage - at {x.ScheduleKilometer.ToString()} kilometer";
                        }
                        else
                        {
                            return $"Monthly - at {x.ScheduleDate.Value.Date.ToString("yyyy/MM/dd")}";
                        }
                    })(),
                    x.TaskDone,
                    Color = new Func<string>(() =>
                    {
                        if (x.PMScheduleTypeID == 1 && x.TaskDone == false)
                        {
                            return "black";
                        }

                        if (x.PMScheduleTypeID == 1 && x.TaskDone == true)
                        {
                            return "gray";
                        }

                        if (x.PMScheduleTypeID == 2 && x.ScheduleDate < ActiveDate && x.TaskDone == true)
                        {
                            return "orange";
                        }

                        if (x.PMScheduleTypeID == 2 && x.ScheduleDate < ActiveDate && x.TaskDone == false)
                        {
                            return "red";
                        }

                        if (x.PMScheduleTypeID == 2 && x.ScheduleDate == ActiveDate && x.TaskDone == false)
                        {
                            return "black";
                        }

                        if (x.PMScheduleTypeID == 2 && x.ScheduleDate == ActiveDate && x.TaskDone == true)
                        {
                            return "green";
                        }

                        if (x.PMScheduleTypeID == 2 && x.ScheduleDate > ActiveDate && x.TaskDone == false)
                        {
                            return "purple";
                        }

                        if (x.PMScheduleTypeID == 2 && x.ScheduleDate > ActiveDate && x.TaskDone == true)
                        {
                            return "black";
                        }

                        return "black";
                    })()
                });

            return getPmList;
        }
    }
}
