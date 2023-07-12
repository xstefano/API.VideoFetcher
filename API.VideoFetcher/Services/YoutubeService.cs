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

        public async Task<string> GetBestUrlVideo(string videoUrl)
        {
            var decodeUrl = HttpUtility.UrlDecode(videoUrl);
            var id = ExtractVideoId(decodeUrl);
            var video = GetVideo(id);

            if (video != null)
            {
                var streamManifest = await _youtubeClient.Videos.Streams.GetManifestAsync(video.Result.Url);
                var streamInfo = streamManifest.GetMuxedStreams().GetWithHighestVideoQuality();
                return streamInfo.Url;
            }
            return null;
        }

        public async Task<IEnumerable<MuxedStreamInfo>> GetContainerMp4(string videoUrl)
        {
            var decodedUrl = HttpUtility.UrlDecode(videoUrl);
            var id = ExtractVideoId(decodedUrl);
            var video = GetVideo(id);

            if (video != null)
            {
                var streamManifest = await _youtubeClient.Videos.Streams.GetManifestAsync(video.Result.url);
                var streamInfo = streamManifest.GetMuxedStreams().Where(s => s.Container == Container.Mp4);
                return streamInfo;
            }
            return null;
        }

        public async Task<IEnumerable<AudioOnlyStreamInfo>> GetCointanerM4a(string videoUrl)
        {
            var decodedUrl = HttpUtility.UrlDecode(videoUrl);
            var id = ExtractVideoId(decodedUrl);
            var video = GetVideo(id);

            if (video != null)
            {
                var streamManifest = await _youtubeClient.Videos.Streams.GetManifestAsync(video.Result.Url);
                var streamInfo = streamManifest.GetAudioOnlyStreams().Where(s => s.Container == Container.Mp4); ;
                return streamInfo;
            }
            return null;
        }

        public async Task<Stream> DownloadMp4(string videoUrl, string url)
        {
            var streamInfo = GetContainerMp4(videoUrl);

            if (streamInfo != null)
            {
                var streamInfoF = streamInfo.Result.Where(x => x.VideoQuality.Label == quality).FirstOrDefault();
                var stream = await _youtubeClient.Videos.Streams.GetAsync(streamInfoF);
                return stream;
            }
            return null;
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
