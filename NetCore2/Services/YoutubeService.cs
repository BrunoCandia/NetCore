using Microsoft.Extensions.Configuration;
using NetCore2.Client.Interfaces;
using NetCore2.DTO;
using NetCore2.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore2.Services
{
    public class YoutubeService : IYoutubeService
    {
        public const string GoogleApi = "APIsKeys:GoogleApi";

        private readonly IYoutubeClient youtubeClient;
        private readonly IConfiguration configuration;

        public YoutubeService(IYoutubeClient youtubeClient, IConfiguration configuration)
        {
            this.youtubeClient = youtubeClient;
            this.configuration = configuration;
        }

        public async Task<YoutubeDTO> GetChannelInfoAsync(string channelId)
        {
            //Real Madrid channel Id: UCWV3obpZVGgJ3j9FVhEjF2Q

            var apiKey = configuration.GetValue<string>(GoogleApi);   //"AIzaSyA2zKwlat-2_nlbjvXowFbU_YXRuaj_DoE";

            return await this.youtubeClient.GetChannelInfoAsync<YoutubeDTO>(channelId, apiKey);
        }
    }
}
