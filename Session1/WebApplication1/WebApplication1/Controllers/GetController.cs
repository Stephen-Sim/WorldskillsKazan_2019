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
        WSC2019_Session1Entities ent = new WSC2019_Session1Entities();

        [HttpGet]
        public object getAssetList()
        {
            return ent.Assets.ToList().Select(x => new
            {
                AssetID = x.ID,
                x.AssetName,
                x.AssetSN,
                Location = x.DepartmentLocation.Location.Name
            });
        }

        [HttpPost]
        public object getAssetList(AssetRequest assetRequest)
        {
            var AssetList = ent.Assets.ToList();

            if (assetRequest.AssetGroupId != 0)
            {
                AssetList = AssetList.Where(x => x.AssetGroupID == assetRequest.AssetGroupId).ToList();
            }

            if (assetRequest.DepartmentId != 0)
            {
                AssetList = AssetList.Where(x => x.DepartmentLocation.LocationID == assetRequest.DepartmentId).ToList();
            }

            if (!string.IsNullOrEmpty(assetRequest.SearchContent))
            {
                AssetList = AssetList.Where(x => x.Description.Contains(assetRequest.SearchContent)).ToList();
            }

            AssetList = AssetList.Where(x => x.WarrantyDate >= assetRequest.StartDate && x.WarrantyDate <= assetRequest.EndDate).ToList();

            return AssetList.Select(x => new
            {
                AssetID = x.ID,
                x.AssetName,
                x.AssetSN,
                Location = x.DepartmentLocation.Location.Name
            });
        }
    }
}
