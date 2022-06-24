namespace ClientBuilder.KucoinBotClient.Interfaces
{
    public interface IBaseApiClientOptions
    {
        int LogLevel { get; set; }
        bool OutputOriginalData { get; set; }
        string BaseAddress { get; set; }
        IApiProxyConfiguration ApiProxy { get; set; }
    }
}
