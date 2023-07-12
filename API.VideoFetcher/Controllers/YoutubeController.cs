using API.VideoFetcher.Interfaces;
using API.VideoFetcher.Message;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.VideoFetcher.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YoutubeController : ControllerBase
    {
        private readonly IYoutubeService _youtubeService;
        protected Response _response;

        public YoutubeController(IYoutubeService youtubeService)
        {
            _youtubeService = youtubeService;
            _response = new Response();
        }
    }
}
