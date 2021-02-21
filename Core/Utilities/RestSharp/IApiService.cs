using System.Collections.Generic;

namespace Core.Utilities.RestSharp
{
    public interface IApiService
    {
        T Delete<T>(string url, object requestObject, Dictionary<string, string> headers = null);
        T Get<T>(string url, Dictionary<string, string> headers = null);
        T Post<T>(string url, object requestObject, Dictionary<string, string> headers = null);
        T Put<T>(string url, object requestObject, Dictionary<string, string> headers = null);
    }
}