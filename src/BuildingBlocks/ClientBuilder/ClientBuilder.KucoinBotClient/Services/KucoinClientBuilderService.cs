namespace ClientBuilder.KucoinBotClient.Services
{
    public class KucoinClientBuilderService : IKucoinClientBuilderService
    {
        private readonly IUserCredentials _userCredentials;
        private readonly ApiRestClientOptions _restClientOptions;

        public KucoinClientBuilderService(
            IOptions<ApiRestClientOptions> restClientOptions,
            IUserCredentials userCredentials)
        {
            _userCredentials = userCredentials;
            _restClientOptions = restClientOptions.Value;
        }

        public IKucoinClient GetClient()
            => new KucoinClient(GetClientOptions());

        public KucoinClientOptions GetClientOptions()
            =>_userCredentials.IsEmpty() 
                ? KucoinClientOptions.Default 
                : new KucoinClientOptions()
                {
                    ApiCredentials = _userCredentials.SpotCredentials,
                    SpotApiOptions = _restClientOptions.GetKucoinRestApiClientOptions(_userCredentials.SpotCredentials),
                    FuturesApiOptions = _restClientOptions.GetKucoinRestApiClientOptions(_userCredentials.FutureCredentials),
                    LogLevel = _restClientOptions.LogLevel.GetEnum<LogLevel>(),
                    OutputOriginalData = _restClientOptions.OutputOriginalData,
                    Proxy = _restClientOptions.ApiProxy?.GetApiProxy(),
                    RequestTimeout = _restClientOptions.RequestSecondsTimeout.GetSecondsInterval()
                };
    }
}
