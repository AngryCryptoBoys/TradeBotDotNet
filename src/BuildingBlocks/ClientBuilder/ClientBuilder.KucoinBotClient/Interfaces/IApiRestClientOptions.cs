namespace ClientBuilder.KucoinBotClient.Interfaces
{
    public interface IApiRestClientOptions : IBaseApiClientOptions
    {
        bool AutoTimestamp { get; set; }
        int RateLimitingBehaviour { get; set; }
        int RequestSecondsTimeout { get; set; }
        int TimestampRecalculationIntervalInSeconds { get; set; }
        KucoinRestApiClientOptions GetKucoinRestApiClientOptions(KucoinApiCredentials apiCredentials);
    }
}
