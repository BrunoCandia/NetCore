using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore2.Client.Interfaces
{
    public interface IYoutubeClient
    {
        Task<T> GetChannelInfoAsync<T>(string channelId, string apiKey);
    }
}
