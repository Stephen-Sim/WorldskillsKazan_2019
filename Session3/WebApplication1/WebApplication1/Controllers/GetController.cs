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
        WSC2019_Session3Entities ent;
        
        [HttpGet]
        public object GetActiveTask(DateTime activeDate)
        {
            ent = new WSC2019_Session3Entities();

            var getPmList = ent.PMTasks.ToList()
                .Where(x => x.ScheduleDate == null || x.ScheduleDate.Value.Date <= activeDate.AddDays(4).Date)
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

                        if (x.PMScheduleTypeID == 2 && x.ScheduleDate < activeDate && x.TaskDone == true)
                        {
                            return "orange";
                        }

                        if (x.PMScheduleTypeID == 2 && x.ScheduleDate < activeDate && x.TaskDone == false)
                        {
                            return "red";
                        }

                        if (x.PMScheduleTypeID == 2 && x.ScheduleDate == activeDate && x.TaskDone == false)
                        {
                            return "black";
                        }

                        if (x.PMScheduleTypeID == 2 && x.ScheduleDate == activeDate && x.TaskDone == true)
                        {
                            return "green";
                        }

                        if (x.PMScheduleTypeID == 2 && x.ScheduleDate > activeDate && x.TaskDone == false)
                        {
                            return "purple";
                        }

                        if (x.PMScheduleTypeID == 2 && x.ScheduleDate > activeDate && x.TaskDone == true)
                        {
                            return "black";
                        }

                        return "black";
                    })()
                });

            return getPmList;
        }

        [HttpGet]
        public object ChangeTaskStatus(long pmId)
        {
            ent = new WSC2019_Session3Entities();
            try
            {
                var pm = ent.PMTasks.FirstOrDefault(x => x.ID == pmId);
                pm.TaskDone = !pm.TaskDone;
                ent.SaveChanges();

                return Ok("success");
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}
