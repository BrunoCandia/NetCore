using NetCore2.Client.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace NetCore2.Client
{
    public class YoutubeClient : IYoutubeClient
    {
        private readonly HttpClient httpClient;

        public YoutubeClient()
        {
            this.httpClient = new HttpClient {
                BaseAddress = new Uri("https://www.googleapis.com/youtube/v3/")
            };

            this.httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<T> GetChannelInfoAsync<T>(string channelId, string apiKey)
        {
            var response = await this.httpClient.GetAsync($"channels?part=id,snippet,brandingSettings,contentDetails,statistics,topicDetails&id={channelId}&key={apiKey}");

            if (!response.IsSuccessStatusCode)
            {
                return default(T);
            }

            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(result);
        }
    }
}
