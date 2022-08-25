using App1.models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace App1.services
{
    public class GetService
    {
        private string url = "http://10.105.13.82:45456/api/get";
        private HttpClient conn = new HttpClient();

        public async Task<List<AssetList>> getAssetList()
        {
            try
            {
                string url = $"{this.url}/getAssetList";
                var res = await conn.GetStringAsync(url);
                var result = JsonConvert.DeserializeObject<List<AssetList>>(res);
                return result;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }

        public async Task<List<AssetList>> getAssetList(AssetRequest assetRequest)
        {
            try
            {
                var json = JsonConvert.SerializeObject(assetRequest);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                string url = $"{this.url}/getAssetList";
                var res = await conn.PostAsync(url, content);
                var result = res.Content.ReadAsStringAsync();
                var list = JsonConvert.DeserializeObject<List<AssetList>>(result.Result);
                return list;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }
    }
}
