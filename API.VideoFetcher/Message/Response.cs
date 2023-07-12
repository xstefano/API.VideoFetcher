namespace API.VideoFetcher.Message
{
    public class Response
    {
        public bool IsSucces { get; set; } = true;
        public object? Result { get; set; }
        public string? DisplayMessage { get; set; }
        public List<string>? ErrorMessages { get; set; }
    }
}
