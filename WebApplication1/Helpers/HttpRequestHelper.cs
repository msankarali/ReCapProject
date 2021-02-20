using Core.Utilities.Results;
using Entities.Concrete;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Helpers
{
    public class HttpRequestHelper : IHttpRequestHelper
    {
        private readonly string Baseurl = "https://localhost:44334/api/";
        public async Task<ViewDataResult<T>> SendRequest<T>(string url)
        {
            ViewDataResult<T> result = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync(Baseurl + url);

                if (Res.IsSuccessStatusCode)
                {
                    var response = Res.Content.ReadAsStringAsync().Result;
                    result = JsonConvert.DeserializeObject<ViewDataResult<T>>(response);
                }
                return await Task.Run(() => { return result; });
            }
        }
    }
}
