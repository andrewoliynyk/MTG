using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DesktopMTG.Services
{
    public class ApiMTGService
    {
        private readonly string _apiString = @"http://localhost:64649/api/";
        private readonly HttpClient _client;

        protected ApiMTGService()
        {
            var handler = new HttpClientHandler();

            _client = new HttpClient(handler);
            _client.BaseAddress = new Uri(_apiString);
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<HttpResponseMessage> Get(string rest)
        {
            return await _client.GetAsync(rest);
        }

        public async Task<HttpResponseMessage> Post(string url, KeyValuePair<string, string>[] A)
        {
            var content = new FormUrlEncodedContent(A);
            var result = await _client.PostAsync(url, content);
            return result;
        }

        public async Task<HttpResponseMessage> Put(string url, KeyValuePair<string, string>[] A)
        {
            var content = new FormUrlEncodedContent(A);
            var result = await _client.PutAsync(url, content);
            return result;
        }

        public async Task<HttpResponseMessage> Delete(string url)
        {
            var result = await _client.DeleteAsync(url);
            return result;
        }
    }
}
