using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ArticlesClient
{
    public class HttpRequester
    {
        private const string ApplicationJson = "application/json";

        private readonly HttpClient client;
        private readonly string baseUrl;

        public HttpRequester(string baseUrl)
        {
            this.client = new HttpClient();
            this.baseUrl = baseUrl;
        }

        public T Get<T>(string serviceUrl, string mediaType = ApplicationJson)
        {
            if (mediaType == ApplicationJson)
            {
                var request = new HttpRequestMessage();

                request.RequestUri = new Uri(this.baseUrl + serviceUrl);
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));
                request.Method = HttpMethod.Get;

                var response = client.SendAsync(request).Result;

                var returnObjAsString = response.Content.ReadAsStringAsync().Result;
                var returnObj = JsonConvert.DeserializeObject<T>(returnObjAsString);

                return returnObj;
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
