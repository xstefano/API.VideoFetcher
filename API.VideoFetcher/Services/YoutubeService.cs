using API.VideoFetcher.Interfaces;
using YoutubeExplode;
using YoutubeExplode.Videos;
using YoutubeExplode.Videos.Streams;
using System.Web;
using System.Text.RegularExpressions;

namespace API.VideoFetcher.Services
{
    public class YoutubeService : IYoutubeService
    {
        private readonly YoutubeClient _youtubeClient;

        public YoutubeService()
        {
            _youtubeClient = new YoutubeClient();
        }

        public async Task<Video> GetVideo(string videoUrl)
        {
            var decodeUrl = HttpUtility.UrlDecode(videoUrl);
            var id = ExtractVideoId(decodeUrl);
            return await _youtubeClient.Videos.GetAsync(id);
        }

        public Task<string> GetBestUrlVideo(string videoUrl)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MuxedStreamInfo>> GetContainerMp4(string videoUrl)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AudioOnlyStreamInfo>> GetCointanerM4a(string videoUrl)
        {
            throw new NotImplementedException();
        }

        public Task<Stream> DownloadMp4(string videoUrl, string url)
        {
            throw new NotImplementedException();
        }

        public Task<Stream> DownloadM4a(string videoUrl, int bytes)
        {
            throw new NotImplementedException();
        }

        private string ExtractVideoId(string videoUrl) 
        {
            string pattern = @"^(?:https?:\/\/)?(?:www\.)?(?:youtube\.com\/watch\?v=|youtu\.be\/)?([a-zA-Z0-9_-]{11})$";
            var match = Regex.Match(videoUrl, pattern);
            return match.Groups[1].Value;
        }
    }
}
