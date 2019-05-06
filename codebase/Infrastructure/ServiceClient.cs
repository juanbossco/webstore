using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;

namespace Webstore.Infrastructure
{
    public static class ServiceClient
    {
        public static async Task<T> GetAsync<T>(string url)
        {
            T result;

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<T>(responseBody);
            }

            return result;
        }

        public static async Task<T> PostAsync<T>(string url, object body)
        {
            T result;

            using (HttpClient client = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
                var response = await client.PostAsync(url, content);
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<T>(responseBody);
            }
            return result;
        }

        public static async Task<T> GetAsync<T>(HttpClient client, string url)
        {
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<T>(responseBody);

            return result;
        }

        public static async Task<T> PostAsync<T>(HttpClient client, string url, object body)
        {
            var content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
            var response = await client.PostAsync(url, content);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<T>(responseBody);

            return result;
        }
    }
}