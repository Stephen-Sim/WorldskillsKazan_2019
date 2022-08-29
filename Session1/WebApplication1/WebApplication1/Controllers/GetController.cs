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
            ent = new WSC2019_Session1Entities();

            return ent.Assets.ToList().Select(x => new
            {
                AssetID = x.ID,
                x.AssetName,
                x.AssetSN,
                Location = x.DepartmentLocation.Location.Name,
                Department = x.DepartmentLocation.Department.Name,
                x.AssetGroupID
            });
        }

        [HttpPost]
        public object getAssetList(AssetRequest assetRequest)
        {
            ent = new WSC2019_Session1Entities();

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
                Location = x.DepartmentLocation.Location.Name,
                Department = x.DepartmentLocation.Department.Name,
                x.AssetGroupID
            });
        }

        [HttpGet]
        [Route("api/get/getTransferHistory")]
        public object getTransferHistoryByAssetId(long AssetId)
        {
            ent = new WSC2019_Session1Entities();

            return ent.AssetTransferLogs.Where(x => x.AssetID == AssetId).ToList().Select(x => new
            {
                TransferDate = x.TransferDate.ToString("dd/MM/yyyy"),
                OldDepartment = ent.DepartmentLocations.Where(y => y.ID == x.FromDepartmentLocationID).First().Department.Name,
                OldAssetSN = x.FromAssetSN,
                NewDepartment = ent.DepartmentLocations.Where(y => y.ID == x.ToDepartmentLocationID).First().Department.Name,
                NewAssetSN = x.ToAssetSN,
            });
        }

        [HttpGet]
        public object getAssetById(long id)
        {
            ent = new WSC2019_Session1Entities();

            return ent.Assets.Select(x => new
            {
                x.ID,
                x.AssetName,
                x.AssetSN,
                x.AssetGroupID,
                x.Description,
                x.EmployeeID,
                x.WarrantyDate,
                LocationID = x.DepartmentLocation.LocationID,
                DepartmentID = x.DepartmentLocation.DepartmentID
            }).FirstOrDefault(x => x.ID == id);
        }

        [HttpPost]
        public object storeAsset(AddAssetRequest addAssetRequest)
        {
            ent = new WSC2019_Session1Entities();

            try
            {
                Asset asset = addAssetRequest.AssetID != null ? ent.Assets.FirstOrDefault(x => x.ID == addAssetRequest.AssetID) : new Asset();
                asset.AssetName = addAssetRequest.AssetName;
                asset.Description = addAssetRequest.AssetDesc;
                asset.WarrantyDate = addAssetRequest.ExpiredDate;
                asset.EmployeeID = addAssetRequest.EmployeeId;
                asset.AssetGroupID = addAssetRequest.AssetGroupId;

                var whichDepartmentLocation = ent.DepartmentLocations.FirstOrDefault(x => x.DepartmentID == addAssetRequest.DepartmentId && x.LocationID == addAssetRequest.LocationId);

                if (whichDepartmentLocation == null)
                {
                    whichDepartmentLocation = new DepartmentLocation();
                    whichDepartmentLocation.DepartmentID = addAssetRequest.DepartmentId;
                    whichDepartmentLocation.LocationID = addAssetRequest.LocationId;
                    whichDepartmentLocation.StartDate = DateTime.Now;

                    ent.DepartmentLocations.Add(whichDepartmentLocation);
                    ent.SaveChanges();
                }

                asset.DepartmentLocationID = whichDepartmentLocation.ID;
                var whichAsset = ent.Assets.Where(x => x.DepartmentLocation.DepartmentID == addAssetRequest.DepartmentId && x.AssetGroupID == addAssetRequest.AssetGroupId).ToList().OrderByDescending(x => x.ID).FirstOrDefault();
                var lastFourDigit = whichAsset == null ? "0001" : (int.Parse(whichAsset.AssetSN.Substring(7)) + 1).ToString("0000");
                asset.AssetSN = $"{addAssetRequest.DepartmentId.ToString().PadLeft(2, '0')}/{addAssetRequest.AssetGroupId.ToString().PadLeft(2, '0')}/{lastFourDigit}";
                
                if (addAssetRequest.AssetID == null)
                {
                    ent.Assets.Add(asset);
                }
                
                ent.SaveChanges();

                return Ok();
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return BadRequest();
            }
        }

        [HttpPost]
        public object assetTransfer(AssetTransferRequest assetTransferRequest)
        {
            ent = new WSC2019_Session1Entities();
            try
            {
                var asset = ent.Assets.FirstOrDefault(x => x.ID == assetTransferRequest.AssetID);


                AssetTransferLog assetTransferLog = new AssetTransferLog();
                assetTransferLog.AssetID = assetTransferRequest.AssetID;
                assetTransferLog.FromAssetSN = asset.AssetSN;
                assetTransferLog.FromDepartmentLocationID = asset.DepartmentLocationID;
                assetTransferLog.TransferDate = DateTime.Now;

                var whichDepartmentLocation = ent.DepartmentLocations.FirstOrDefault(x => x.DepartmentID == assetTransferRequest.NewDepartmentId && x.LocationID == assetTransferRequest.NewLocationId);

                if (whichDepartmentLocation == null)
                {
                    whichDepartmentLocation = new DepartmentLocation();
                    whichDepartmentLocation.DepartmentID = assetTransferRequest.NewDepartmentId;
                    whichDepartmentLocation.LocationID = assetTransferRequest.NewLocationId;
                    whichDepartmentLocation.StartDate = DateTime.Now;

                    ent.DepartmentLocations.Add(whichDepartmentLocation);
                    ent.SaveChanges();
                }

                assetTransferLog.ToDepartmentLocationID = whichDepartmentLocation.ID;

                var whichAsset = ent.Assets.Where(x => x.DepartmentLocation.DepartmentID == assetTransferRequest.NewDepartmentId && x.AssetGroupID == assetTransferRequest.AssetGroupId).ToList().OrderByDescending(x => x.ID).FirstOrDefault();
                var lastFourDigit = whichAsset == null ? "0001" : (int.Parse(whichAsset.AssetSN.Substring(7)) + 1).ToString("0000");
                asset.AssetSN = $"{assetTransferRequest.NewDepartmentId.ToString().PadLeft(2, '0')}/{assetTransferRequest.AssetGroupId.ToString().PadLeft(2, '0')}/{lastFourDigit}";

                assetTransferLog.ToAssetSN = asset.AssetSN;
                ent.AssetTransferLogs.Add(assetTransferLog);
                ent.Assets.Append(asset);
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
