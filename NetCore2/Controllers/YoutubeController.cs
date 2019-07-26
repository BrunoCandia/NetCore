using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCore2.DTO;
using NetCore2.Services.Interfaces;

namespace NetCore2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YoutubeController : ControllerBase
    {
        private readonly IYoutubeService youtubeService;

        public YoutubeController(IYoutubeService youtubeService)
        {
            this.youtubeService = youtubeService;
        }

        [HttpGet]
        public async Task<YoutubeDTO> GetChannelInfoAsync(string channelId)
        {
            return await this.youtubeService.GetChannelInfoAsync(channelId);
        }

        [HttpGet("getChannelInfo2Async")]
        [Produces("application/json", Type = typeof(YoutubeDTO))]
        public async Task<IActionResult> GetChannelInfo2Async(string channelId)
        {
            return Ok(await this.youtubeService.GetChannelInfoAsync(channelId));
        }
    }
}