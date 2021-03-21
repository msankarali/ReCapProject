using Core.Utilities.IoC;
using Core.Utilities.RestSharp;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Utilities.RestsharpClient.ApiClient
{
    public class ApiService : IApiService
    {
        protected readonly string _apiBaseUrl = "https://localhost:44334/api/";
        //public ApiService(IOptions<RestSharpSettings> appSettings) => _apiBaseUrl = appSettings.Value.ApiBaseUrl;
        //public ApiService(string baseUrl) => _apiBaseUrl = baseUrl;

        public T Get<T>(string url, Dictionary<string, string> headers = null) => GetResult<T>(url, Method.GET, null, headers);
        public T Post<T>(string url, object requestObject, Dictionary<string, string> headers = null) => GetResult<T>(url, Method.POST, requestObject, headers);
        public T Put<T>(string url, object requestObject, Dictionary<string, string> headers = null) => GetResult<T>(url, Method.PUT, requestObject, headers);
        public T Delete<T>(string url, object requestObject, Dictionary<string, string> headers = null) => GetResult<T>(url, Method.DELETE, requestObject, headers);

        private T GetResult<T>(string url, Method method, object requestObject = null, Dictionary<string, string> headers = null)
        {
            var client = new RestClient(_apiBaseUrl);
            var request = new RestRequest(url, method) { RequestFormat = DataFormat.Json };
            var rs = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
            if (headers != null)
                foreach (var header in rs.HttpContext.Request.Headers)
                    //foreach (var header in headers)
                    request.AddHeader(header.Key, header.Value);

            if (requestObject != null)
                request.AddJsonBody(requestObject);

            var response = client.Execute(request);
            return JsonConvert.DeserializeObject<T>(response.Content, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }
    }
}
