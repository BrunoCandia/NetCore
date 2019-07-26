using NetCore2.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore2.Services.Interfaces
{
    public interface IYoutubeService
    {
        Task<YoutubeDTO> GetChannelInfoAsync(string channelId);
    }
}
