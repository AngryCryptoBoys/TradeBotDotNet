namespace ClientBuilder.KucoinBotClient.Configurations
{
    public class BaseApiClientOptions
    {
        public int LogLevel { get; set; }
        public bool OutputOriginalData { get; set; }
        public string BaseAddress { get; set; }
        public ApiProxyConfiguration ApiProxy { get; set; }
    }
}
