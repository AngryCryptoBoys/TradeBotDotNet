using Xunit;
using Kucoin.Net.Objects;
using ClientBuilder.KucoinBotClient.Models;
using ClientBuilder.KucoinBotClient.Services;
using ClientBuilder.KucoinBotClient.Interfaces;
using ClientBuilder.KucoinBotClient.Configurations;

namespace ClientBuilder.Tests.KucoinBotClient.Services
{
    public class KucoinSocketClientBuilderServiceTests
    {
        private readonly IApiCredentials _spotCredentials;
        private readonly IApiCredentials _futureCredentials;
        private readonly IApiSocketClientOptions _apiSocketClientOptions;

        public KucoinSocketClientBuilderServiceTests()
        {
            _spotCredentials = new ApiCredentials()
            {
                ApiKey = "spotCredentials",
                ApiSecret = "spotCredentials",
                ApiPassPhrase = "spotCredentials"
            };
            _futureCredentials = new ApiCredentials()
            {
                ApiKey = "spotCredentials",
                ApiSecret = "spotCredentials",
                ApiPassPhrase = "spotCredentials"
            };
            _apiSocketClientOptions = new ApiSocketClientOptions()
            {
                AutoReconnect = default,
                MaxConcurrentResubscriptionsPerSocket = default,
                MaxReconnectTries = default,
                MaxResubscribeTries = default,
                MaxSocketConnections = default,
                ReconnectSecondsInterval = default,
                SocketNoDataSecondsTimeout = default,
                SocketResponseSecondsTimeout = default,
                SocketSubscriptionsCombineTarget = default,
                LogLevel = default,
                OutputOriginalData = default,
                BaseAddress = "",
                ApiProxy = new ApiProxyConfiguration()
                {
                    Host = default,
                    Port = default,
                    Login = default,
                    Password = default
                }
            };
        }

        [Fact]
        public void GetClientOptions_InsertEmptyCredentials_ReturnDefaultKucoinSocketClientOptions()
        {
            //Arrange
            var userCredentials = new UserCredentials(
                spotCredentials: default(ApiCredentials),
                futureCredentials: default(ApiCredentials));

            var service = new KucoinSocketClientBuilderService(
                userCredentials: userCredentials,
                socketClientOptions: _apiSocketClientOptions);

            //Act
            var actualClient = service.GetClientOptions();

            //Assert
            Assert.Equal(actualClient, KucoinSocketClientOptions.Default);
        }
    }
}
