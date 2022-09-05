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
        Models.WSC2019_Session5Entities ent;

        [HttpGet]
        public object GetWells()
        {
            ent = new WSC2019_Session5Entities();
            return ent.Wells.ToList();
        }


        [HttpGet]
        public object GetWellLayers(long WellId)
        {
            ent = new WSC2019_Session5Entities();
            var wellLayers = ent.WellLayers.Where(x => x.WellID == WellId).OrderBy(x => x.StartPoint).Select(x => new
            {
                x.RockType.Name,
                x.StartPoint,
                x.EndPoint,
                x.RockType.BackgroundColor,
                TextColor = "Black",
                Depth = (x.EndPoint - x.StartPoint) / 10
            }).ToList();

            wellLayers.Add(new
            {
                Name = "Oil and Gas",
                StartPoint = ent.Wells.FirstOrDefault(x => x.ID == WellId).GasOilDepth,
                EndPoint = ent.Wells.FirstOrDefault(x => x.ID == WellId).GasOilDepth + 500,
                BackgroundColor = "Black",
                TextColor = "White",
                Depth = (long)500 / 10
            });

            return wellLayers;
        }

        [HttpPost]
        public object StoreWell(WellRequest wellRequest)
        {
            ent = new WSC2019_Session5Entities();
            try
            {
                bool isUpdate = wellRequest.WellID != 0;

                Well well = isUpdate ? ent.Wells.FirstOrDefault(x => x.ID == wellRequest.WellID) : new Well();
                well.WellName = wellRequest.WellName;
                well.WellTypeID = wellRequest.WellTypeID;
                well.GasOilDepth = wellRequest.GasOilDepth;
                well.Capacity = wellRequest.Capacity;

                if (!isUpdate)
                {
                    ent.Wells.Add(well);
                }

                var wellLyars = ent.WellLayers.Where(x => x.WellID == well.ID).ToList();

                foreach (var item in wellLyars)
                {
                    ent.WellLayers.Remove(item);
                }

                for (int i = 0; i < wellRequest.RockLayers.Count; i++)
                {
                    WellLayer wellLayer = new WellLayer();
                    wellLayer.WellID = well.ID;
                    wellLayer.RockTypeID = wellRequest.RockLayers[i].RockId;
                    wellLayer.StartPoint = wellRequest.RockLayers[i].FromDepth;
                    wellLayer.EndPoint = wellRequest.RockLayers[i].ToDepth;
                    ent.WellLayers.Add(wellLayer);
                }
                
                ent.SaveChanges();

                return Ok();
            }
            catch (Exception err)
            {
                Console.WriteLine(err.InnerException.Message);
                return BadRequest();
            }
        }
    }
}
