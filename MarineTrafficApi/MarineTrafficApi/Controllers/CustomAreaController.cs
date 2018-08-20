using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Diagnostics;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace MarineTrafficApi.Controllers
{
    public class CustomAreaController : ApiController
    {
        private HttpClient apiClient;
        private string uri = "";

        public CustomAreaController()
        {
            this.apiClient = new HttpClient();
            this.apiClient.BaseAddress = new Uri("https://services.marinetraffic.com/api/");
            this.apiClient.DefaultRequestHeaders.Accept.Clear();
            this.apiClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
        
        // GET: api/CustomArea
        public async Task<JArray> Get(string minLat, string maxLat, string minLong, string maxLong)
        {
            JArray jArray = null;

            try
            {
                /*
                 * 
                 * minLat =-23.97990172 
                   minLong = -46.29046404
                   maxLat = -23.98021541
                   maxLong = -46.28634417
                 */

                this.uri = "exportvessels/v:8/fc7621e8c6a8510248e12b8c0e8e4bc48dfc5a5a/MINLAT:" + minLat + "/MAXLAT:" + maxLat + "/MINLON:" + minLong + "/MAXLON:" + maxLong +
                    "/timespan:10/protocol:json";
                
                HttpResponseMessage response = (HttpResponseMessage)await this.apiClient.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    jArray = await response.Content.ReadAsAsync<JArray>();
                }
            }
            catch(Exception e)
            {
                Debug.Write(e.Message);
            }

            return jArray;
            
        }

        // GET: api/CustomArea/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/CustomArea
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/CustomArea/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CustomArea/5
        public void Delete(int id)
        {
        }
    }
}
