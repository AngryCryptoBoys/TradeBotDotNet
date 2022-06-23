using Microsoft.Extensions.Options;

namespace ClientBuilder.KucoinBotClient.Services
{
    public class KucoinClientBuilderService : IKucoinClientBuilderService
    {
        private readonly IUserCredentials _userCredentials;
        private readonly ApiRestClientOptions _options;

        public KucoinClientBuilderService(
            IOptions<ApiRestClientOptions> options,
            IUserCredentials userCredentials)
        {
            _userCredentials = userCredentials;
            _options = options.Value;
        }

        public IKucoinClient GetClient()
            => new KucoinClient(GetClientOptions());

        public KucoinClientOptions GetClientOptions()
            =>_userCredentials.IsEmpty() 
                ? KucoinClientOptions.Default 
                : new KucoinClientOptions()
                {
                    ApiCredentials = _userCredentials.SpotCredentials,
                    SpotApiOptions = _options.GetKucoinRestApiClientOptions(_userCredentials.SpotCredentials),
                    FuturesApiOptions = _options.GetKucoinRestApiClientOptions(_userCredentials.FutureCredentials),
                    LogLevel = _options.LogLevel.GetEnum<LogLevel>(),
                    OutputOriginalData = _options.OutputOriginalData,
                    Proxy = _options.ApiProxy?.GetApiProxy(),
                    RequestTimeout = _options.RequestSecondsTimeout.GetSecondsInterval()
            };
    }
}
