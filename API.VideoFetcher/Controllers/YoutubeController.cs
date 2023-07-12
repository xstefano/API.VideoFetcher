using API.VideoFetcher.Interfaces;
using API.VideoFetcher.Message;
using API.VideoFetcher.Services;
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

        [HttpGet]
        [Route("getvideo/videoUrl={videoUrl}")]
        public async Task<IActionResult> GetVideo(string videoUrl)
        {
            try
            {
                var video = await _youtubeService.GetVideo(videoUrl);

                _response.Result = video;
                _response.DisplayMessage = "Video Information";
            }
            catch (Exception ex)
            {
                _response.IsSucces = false;
                _response.DisplayMessage = "Url incorrect";
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return Ok(_response);
        }

        [HttpGet]
        [Route("urlvideo/videoUrl={videoUrl}")]
        public async Task<IActionResult> GetBestUrlVideo(string videoUrl)
        {
            try
            {
                var url = await _youtubeService.GetBestUrlVideo(videoUrl);

                _response.Result = url;
                _response.DisplayMessage = "Url Information";
            }
            catch (Exception ex)
            {
                _response.IsSucces = false;
                _response.DisplayMessage = "Url incorrect";
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return Ok(_response);
        }

        [HttpGet]
        [Route("getcontainer/videoUrl={videoUrl}")]
        public async Task<IActionResult> GetContainerMp4(string videoUrl)
        {
            try
            {
                var videos = await _youtubeService.GetContainerMp4(videoUrl);

                _response.Result = videos;
                _response.DisplayMessage = "Video Information";
            }
            catch (Exception ex)
            {
                _response.IsSucces = false;
                _response.DisplayMessage = "Url incorrect";
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return Ok(_response);
        }

    }
}
