using App1.models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace App1.services
{
    public class GetService
    {
        string url = "http://10.105.13.82:45455/api/get/";
        HttpClient conn = new HttpClient();

        public async Task<List<PMList>> GetActiveTask(DateTime date)
        {
            try
            {
                string url = $"{this.url}GetActiveTask?activeDate={date}";
                var response = await conn.GetStringAsync(url);
                var result = JsonConvert.DeserializeObject<List<PMList>>(response);
                return new List<PMList>(result);
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }

        public async Task<HttpStatusCode> ChangeTaskStatus(long pmId)
        {
            try
            {
                string url = $"{this.url}ChangeTaskStatus?pmId={pmId}";
                var response = await conn.GetAsync(url);
                return response.StatusCode;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return HttpStatusCode.BadRequest;
            }
        }

        public async Task<HttpStatusCode> StorePMTask(PMTaskRequest pmTaskRequest)
        {
            try
            {
                string url = $"{this.url}StorePMTask";
                string json = JsonConvert.SerializeObject(pmTaskRequest);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await conn.PostAsync(url, content);
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
