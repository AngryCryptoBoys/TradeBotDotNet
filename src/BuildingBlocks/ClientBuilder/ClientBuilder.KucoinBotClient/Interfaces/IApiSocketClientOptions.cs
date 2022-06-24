namespace ClientBuilder.KucoinBotClient.Interfaces
{
    public interface IApiSocketClientOptions : IBaseApiClientOptions
    {
        bool AutoReconnect { get; set; }
        int MaxConcurrentResubscriptionsPerSocket { get; set; }
        int? MaxReconnectTries { get; set; }
        int? MaxResubscribeTries { get; set; }
        int? MaxSocketConnections { get; set; }
        int ReconnectSecondsInterval { get; set; }
        int SocketNoDataSecondsTimeout { get; set; }
        int SocketResponseSecondsTimeout { get; set; }
        int? SocketSubscriptionsCombineTarget { get; set; }
        KucoinSocketApiClientOptions GetKucoinSocketApiClientOptions(KucoinApiCredentials apiCredentials);
    }
}
