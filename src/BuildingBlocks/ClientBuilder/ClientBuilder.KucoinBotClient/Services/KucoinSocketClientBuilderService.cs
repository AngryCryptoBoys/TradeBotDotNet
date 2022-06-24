namespace ClientBuilder.KucoinBotClient.Services
{
    public class KucoinSocketClientBuilderService : IKucoinSocketClientBuilderService
    {
        private readonly IUserCredentials _userCredentials;
        private readonly IApiSocketClientOptions _socketClientOptions;

        public KucoinSocketClientBuilderService(
            IUserCredentials userCredentials,
            IApiSocketClientOptions socketClientOptions)
        {
            _userCredentials = userCredentials;
            _socketClientOptions = socketClientOptions;
        }

        public IKucoinSocketClient GetClient()
            => new KucoinSocketClient(GetClientOptions());

        public KucoinSocketClientOptions GetClientOptions()
            => _userCredentials.IsEmpty()
                ? KucoinSocketClientOptions.Default
                : new KucoinSocketClientOptions()
                {
                    ApiCredentials = _userCredentials.SpotCredentials,
                    SpotStreamsOptions = _socketClientOptions.GetKucoinSocketApiClientOptions(_userCredentials.SpotCredentials),
                    FuturesStreamsOptions = _socketClientOptions.GetKucoinSocketApiClientOptions(_userCredentials.FutureCredentials),
                    AutoReconnect = _socketClientOptions.AutoReconnect,
                    LogLevel = _socketClientOptions.LogLevel.GetEnum<LogLevel>(),
                    MaxConcurrentResubscriptionsPerSocket = _socketClientOptions.MaxConcurrentResubscriptionsPerSocket,
                    MaxReconnectTries = _socketClientOptions.MaxReconnectTries,
                    MaxResubscribeTries = _socketClientOptions.MaxResubscribeTries,
                    MaxSocketConnections = _socketClientOptions.MaxSocketConnections,
                    OutputOriginalData = _socketClientOptions.OutputOriginalData,
                    ReconnectInterval = _socketClientOptions.ReconnectSecondsInterval.GetSecondsInterval(),
                    SocketNoDataTimeout = _socketClientOptions.SocketNoDataSecondsTimeout.GetSecondsInterval(),
                    SocketResponseTimeout = _socketClientOptions.SocketResponseSecondsTimeout.GetSecondsInterval(),
                    SocketSubscriptionsCombineTarget = _socketClientOptions.SocketSubscriptionsCombineTarget,
                    Proxy = _socketClientOptions.ApiProxy?.GetApiProxy()
                };
    }
}
