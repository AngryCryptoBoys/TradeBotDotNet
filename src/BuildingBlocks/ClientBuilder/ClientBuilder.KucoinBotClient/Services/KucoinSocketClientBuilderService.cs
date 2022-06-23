using Microsoft.Extensions.Options;

namespace ClientBuilder.KucoinBotClient.Services
{
    public class KucoinSocketClientBuilderService : IKucoinSocketClientBuilderService
    {
        private readonly IUserCredentials _userCredentials;
        private readonly ApiSocketClientOptions _options;

        public KucoinSocketClientBuilderService(
            IUserCredentials userCredentials,
            IOptions<ApiSocketClientOptions> options)
        {
            _userCredentials = userCredentials;
            _options = options.Value;
        }

        public IKucoinSocketClient GetClient()
            => new KucoinSocketClient(GetClientOptions());

        public KucoinSocketClientOptions GetClientOptions()
            => _userCredentials.IsEmpty()
                ? KucoinSocketClientOptions.Default
                : new KucoinSocketClientOptions()
                {
                    ApiCredentials = _userCredentials.SpotCredentials,
                    SpotStreamsOptions = _options.GetKucoinSocketApiClientOptions(_userCredentials.SpotCredentials),
                    FuturesStreamsOptions = _options.GetKucoinSocketApiClientOptions(_userCredentials.FutureCredentials),
                    AutoReconnect = _options.AutoReconnect,
                    LogLevel = _options.LogLevel.GetEnum<LogLevel>(),
                    MaxConcurrentResubscriptionsPerSocket = _options.MaxConcurrentResubscriptionsPerSocket,
                    MaxReconnectTries = _options.MaxReconnectTries,
                    MaxResubscribeTries = _options.MaxResubscribeTries,
                    MaxSocketConnections = _options.MaxSocketConnections,
                    OutputOriginalData = _options.OutputOriginalData,
                    ReconnectInterval = _options.ReconnectSecondsInterval.GetSecondsInterval(),
                    SocketNoDataTimeout = _options.SocketNoDataSecondsTimeout.GetSecondsInterval(),
                    SocketResponseTimeout = _options.SocketResponseSecondsTimeout.GetSecondsInterval(),
                    SocketSubscriptionsCombineTarget = _options.SocketSubscriptionsCombineTarget,
                    Proxy = _options.ApiProxy?.GetApiProxy()
                };
    }
}
