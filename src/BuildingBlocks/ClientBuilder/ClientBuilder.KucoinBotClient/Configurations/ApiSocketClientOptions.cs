namespace ClientBuilder.KucoinBotClient.Configurations
{
    public class ApiSocketClientOptions : BaseApiClientOptions
    {
        public bool AutoReconnect { get; set; }
        public int MaxConcurrentResubscriptionsPerSocket { get; set; }
        public int? MaxReconnectTries { get; set; }
        public int? MaxResubscribeTries { get; set; }
        public int? MaxSocketConnections { get; set; }
        public int ReconnectSecondsInterval { get; set; }
        public int SocketNoDataSecondsTimeout { get; set; }
        public int SocketResponseSecondsTimeout { get; set; }
        public int? SocketSubscriptionsCombineTarget { get; set; }

        public KucoinSocketApiClientOptions GetKucoinSocketApiClientOptions(KucoinApiCredentials apiCredentials)
            => new KucoinSocketApiClientOptions()
            {
                ApiCredentials = apiCredentials,
                BaseAddress = this.BaseAddress
            };
    }
}
