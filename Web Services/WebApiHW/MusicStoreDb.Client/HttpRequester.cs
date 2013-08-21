using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace MusicStoreDb.Client
{
    public class HttpRequester
    {
        private const string ApplicationJson = "application/json";
        private const string ApplicationXml = "application/xml";

        private readonly HttpClient client;
        private readonly string baseUrl;

        public HttpRequester(string baseUrl)
        {
            this.client = new HttpClient();
            this.baseUrl = baseUrl;
        }

        public HttpResponseMessage Post<T>(string serviceUrl, T data, string mediaType = ApplicationJson)
        {
            if (mediaType == ApplicationJson)
            {
                var response = this.client.PostAsJsonAsync(this.baseUrl + serviceUrl, data).Result;

                return response;
            }
            else if (mediaType == ApplicationXml)
            {
                var response = this.client.PostAsXmlAsync(this.baseUrl + serviceUrl, data).Result;

                return response;
            }
            else
            {
                return null;
            }
        }

        public T Get<T>(string serviceUrl)
        {
            var response = this.client.GetAsync(this.baseUrl + serviceUrl).Result;;
            var album = response.Content.ReadAsAsync<T>().Result;

            return album;
        }

        public IEnumerable<T> GetAll<T>(string serviceUrl)
        {
            var response = this.client.GetAsync(this.baseUrl + serviceUrl).Result;
            var albums = response.Content.ReadAsAsync<IEnumerable<T>>().Result;

            return albums;
        }

        public HttpResponseMessage Put<T>(string serviceUrl, T data, string mediaType = ApplicationJson)
        {
            if (mediaType == ApplicationJson)
            {
                var response = this.client.PutAsJsonAsync(this.baseUrl + serviceUrl, data).Result;

                return response;
            }
            else if (mediaType == ApplicationXml)
            {
                var response = this.client.PutAsXmlAsync(this.baseUrl + serviceUrl, data).Result;

                return response;
            }
            else
            {
                return null;
            }
        }

        public HttpResponseMessage Delete(string serviceUrl)
        {
            var response = this.client.DeleteAsync(this.baseUrl + serviceUrl).Result;

            return response;
        }
    }
}
