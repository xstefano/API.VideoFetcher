using YoutubeExplode.Videos;
using YoutubeExplode.Videos.Streams;

namespace API.VideoFetcher.Interfaces
{
    public interface IYoutubeService
    {
        Task<Video> GetVideo(string videoUrl);
        Task<string> GetBestUrlVideo(string videoUrl);
        Task<IEnumerable<MuxedStreamInfo>> GetContainerMp4(string videoUrl);
        Task<IEnumerable<AudioOnlyStreamInfo>> GetCointanerM4a(string videoUrl);
        Task<Stream> DownloadMp4(string videoUrl, string url);
        Task<Stream> DownloadM4a(string videoUrl, int bytes);
    }
}
