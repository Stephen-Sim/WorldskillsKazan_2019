using App1.models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;
using Xamarin.Forms;

namespace App1.services
{
    public class GetService
    {
        string url = "http://10.105.13.82:45455/api/get/";
        HttpClient client = new HttpClient();

        public async Task<List<Well>> GetWells()
        {
            try
            {
                string url = $"{this.url}/GetWells";
                var response = await client.GetStringAsync(url);
                return JsonConvert.DeserializeObject<List<Well>>(response);
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }

        public async Task<List<WellLayerRequest>> GetWellLayers(long WellId)
        {
            try
            {
                string url = $"{this.url}/GetWellLayers?WellId={WellId}";
                var response = await client.GetStringAsync(url);
                return JsonConvert.DeserializeObject<List<WellLayerRequest>>(response);
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }

        public async Task<HttpStatusCode> StoreWell(AddWellRequest addWellRequest)
        {
            try
            {
                string url = $"{this.url}/StoreWell";
                var json = JsonConvert.SerializeObject(addWellRequest);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(url, content);
                return response.StatusCode;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return HttpStatusCode.BadRequest;
            }
        }
    }
}
