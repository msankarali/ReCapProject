using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Helpers
{
    public class HttpRequestHelper : IHttpRequestHelper
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _httpClient;

        public HttpRequestHelper(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _httpClient = _httpClientFactory.CreateClient("client");
        }

        public async Task<ViewDataResult<T>> Get<T>(string url)
        {
            var Res = await _httpClient.GetAsync(_httpClient.BaseAddress + url);
            var response = Res.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<ViewDataResult<T>>(response);
            return result;
        }

        public async Task<ViewDataResult<T>> Send<T>(string url, T data)
        {
            var requestObj = JsonConvert.SerializeObject(data);

            var Res = await _httpClient.PostAsJsonAsync(_httpClient.BaseAddress + url, requestObj);
            var response = Res.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<ViewDataResult<T>>(response);

            return result;
        }
    }
}
