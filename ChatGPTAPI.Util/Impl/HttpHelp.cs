using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPTAPI.Util.Impl
{
    public class HttpHelp: IHttpHelp
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public HttpHelp(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public string Post(string url,string parameter,string token)
        {
            string res = string.Empty;
            var client = _httpClientFactory.CreateClient();  
            try
            {
                client.BaseAddress = new Uri(url);
                if (!string.IsNullOrEmpty(token))
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                }
                //client.DefaultRequestHeaders.Add("Content-Type", "application/json; charset=utf-8");
                //HttpContent content = new StringContent(parameter,Encoding.UTF8, "application/json");
                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Authorization", "Bearer " + token);
                message.Content = new StringContent(parameter, System.Text.Encoding.UTF8, "application/json");
                message.Method = HttpMethod.Post;
                message.RequestUri = client.BaseAddress;
                HttpResponseMessage response = client.SendAsync(message).Result;
                res = response.Content.ReadAsStringAsync().Result;

            }
            catch
            {

            }

            return res;
        }
    }
}
