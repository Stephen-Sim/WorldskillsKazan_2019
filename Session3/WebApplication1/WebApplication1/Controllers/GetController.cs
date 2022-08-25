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

                return Ok();
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPost]
        public object StorePMTask(PMRequest pmRequest)
        {
            ent = new WSC2019_Session3Entities();
            try
            {
                for (int i = 0; i < pmRequest.AssetId.Count; i++)
                {
                    if (pmRequest.ModelId != 4)
                    {
                        var startDate = pmRequest.StartDate;
                        var endDate = pmRequest.EndDate;

                        if (pmRequest.TaskId == 1)
                        {
                            int dayInterval = (int)pmRequest.DayIntervalToRun;

                            for (var idate = startDate; idate <= endDate; idate = idate.AddDays(dayInterval))
                            {
                                PMTask pMTask = new PMTask();
                                pMTask.AssetID = pmRequest.AssetId[i];
                                pMTask.PMScheduleTypeID = 2;
                                pMTask.ScheduleDate = idate;
                                pMTask.TaskID = pmRequest.TaskId;
                                pMTask.TaskDone = false;
                                ent.PMTasks.Add(pMTask);
                                ent.SaveChanges();
                            }
                        }
                        else if (pmRequest.ModelId == 2)
                        {
                            int dayInterval = (int)pmRequest.NumbersofWeekstoRun * 7;
                            DayOfWeek dayOfWeek = (DayOfWeek)pmRequest.DayofWeektoRun;

                            while (startDate <= endDate)
                            {
                                if (startDate.DayOfWeek == dayOfWeek)
                                {
                                    PMTask pMTask = new PMTask();
                                    pMTask.AssetID = pmRequest.AssetId[i];
                                    pMTask.PMScheduleTypeID = 2;
                                    pMTask.ScheduleDate = startDate;
                                    pMTask.TaskID = pmRequest.TaskId;
                                    pMTask.TaskDone = false;
                                    ent.PMTasks.Add(pMTask);
                                    ent.SaveChanges();

                                    startDate = startDate.AddDays(dayInterval);
                                    continue;
                                }

                                startDate = startDate.AddDays(1);
                            }
                        }
                        else if (pmRequest.ModelId == 3)
                        {
                            int monthInterval = (int)pmRequest.NumberofMonthstoRun;
                            int dayOfMonth = (int)pmRequest.DayofMonthtoRun;

                            while (startDate <= endDate)
                            {
                                if (startDate.Day == dayOfMonth)
                                {
                                    PMTask pMTask = new PMTask();
                                    pMTask.AssetID = pmRequest.AssetId[i];
                                    pMTask.PMScheduleTypeID = 2;
                                    pMTask.ScheduleDate = startDate;
                                    pMTask.TaskID = pmRequest.TaskId;
                                    pMTask.TaskDone = false;
                                    ent.PMTasks.Add(pMTask);
                                    ent.SaveChanges();

                                    startDate = startDate.AddMonths(monthInterval);
                                    continue;
                                }

                                startDate = startDate.AddDays(1);
                            }
                        }
                    }
                    else
                    {
                        int xKilomter = (int)pmRequest.XKilometerTorun;
                        int startRange = (int) pmRequest.StartRangeKilometer;
                        int endRange = (int) pmRequest.EndRangeKilometer;

                        var checkPMTask = ent.PMTasks.Where(x => x.TaskID == pmRequest.TaskId && x.ScheduleKilometer != null && x.ScheduleKilometer >= startRange && x.ScheduleKilometer <= endRange).ToList();

                        if (checkPMTask.Any())
                        {
                            return BadRequest("Task is already existed!!");
                        }

                        for (int j = startRange; j < endRange; j+=xKilomter)
                        {
                            PMTask pMTask = new PMTask();
                            pMTask.AssetID = pmRequest.AssetId[i];
                            pMTask.PMScheduleTypeID = 1;
                            pMTask.ScheduleKilometer = j;
                            pMTask.TaskID = pmRequest.TaskId;
                            pMTask.TaskDone = false;
                            ent.PMTasks.Add(pMTask);
                            ent.SaveChanges();
                        }
                    }
                }
                return Ok();
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return BadRequest();
            }
        }
    }
}
