namespace ClientBuilder.KucoinBotClient.Configurations
{
    public class BaseApiClientOptions : IBaseApiClientOptions
    {
        public int LogLevel { get; set; }
        public bool OutputOriginalData { get; set; }
        public string BaseAddress { get; set; }
        public IApiProxyConfiguration ApiProxy { get; set; }
    }
}
