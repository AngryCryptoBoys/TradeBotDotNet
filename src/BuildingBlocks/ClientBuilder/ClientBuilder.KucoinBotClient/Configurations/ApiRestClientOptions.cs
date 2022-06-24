namespace ClientBuilder.KucoinBotClient.Configurations
{
    public class ApiRestClientOptions : BaseApiClientOptions
    {
        public bool AutoTimestamp { get; set; }
        public int RateLimitingBehaviour { get; set; }
        public int RequestSecondsTimeout { get; set; }
        public int TimestampRecalculationIntervalInSeconds { get; set; }

        public KucoinRestApiClientOptions GetKucoinRestApiClientOptions(
            KucoinApiCredentials apiCredentials)
            => new KucoinRestApiClientOptions()
            {
                ApiCredentials = apiCredentials,
                AutoTimestamp = this.AutoTimestamp,
                BaseAddress = this.BaseAddress,
                RateLimitingBehaviour = this.RateLimitingBehaviour.GetEnum<RateLimitingBehaviour>(),
                TimestampRecalculationInterval = this.TimestampRecalculationIntervalInSeconds.GetSecondsInterval()
            };
    }
}
