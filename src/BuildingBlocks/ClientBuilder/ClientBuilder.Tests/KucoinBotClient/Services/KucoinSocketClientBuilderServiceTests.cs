using Moq;
using Xunit;
using Kucoin.Net.Objects;
using ClientBuilder.KucoinBotClient.Models;
using ClientBuilder.KucoinBotClient.Services;
using ClientBuilder.KucoinBotClient.Configurations;
using Microsoft.Extensions.Options;

namespace ClientBuilder.Tests.KucoinBotClient.Services
{
    public class KucoinSocketClientBuilderServiceTests
    {
        private readonly Mock<IOptions<SpotApiCredentials>> _mockSpotCredentials;
        private readonly Mock<IOptions<FutureApiCredentials>> _mockFutureCredentials;
        private readonly Mock<IOptions<ApiSocketClientOptions>> _mockApiSocketClientOptions;

        public KucoinSocketClientBuilderServiceTests()
        {
            var spotCredentials = new ApiCredentials()
            {
                ApiKey = "spotCredentials",
                ApiSecret = "spotCredentials",
                ApiPassPhrase = "spotCredentials"
            };
            var futureCredentials = new ApiCredentials()
            {
                ApiKey = "spotCredentials",
                ApiSecret = "spotCredentials",
                ApiPassPhrase = "spotCredentials"
            };
            var apiSocketClientOptions = new ApiSocketClientOptions()
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

            _mockSpotCredentials = new Mock<IOptions<SpotApiCredentials>>();
            _mockFutureCredentials = new Mock<IOptions<FutureApiCredentials>>();
            _mockApiSocketClientOptions = new Mock<IOptions<ApiSocketClientOptions>>();
            _mockApiSocketClientOptions.Setup(_ => _.Value).Returns(apiSocketClientOptions);
        }

        [Fact]
        public void GetClientOptions_InsertEmptyCredentials_ReturnDefaultKucoinSocketClientOptions()
        {
            //Arrange
            _mockSpotCredentials.Setup(_ => _.Value).Returns(default(SpotApiCredentials));
            _mockFutureCredentials.Setup(_ => _.Value).Returns(default(FutureApiCredentials));

            var userCredentials = new UserCredentials(
                spotCredentials: _mockSpotCredentials.Object,
                futureCredentials: _mockFutureCredentials.Object);

            var service = new KucoinSocketClientBuilderService(
                userCredentials: userCredentials,
                socketClientOptions: _mockApiSocketClientOptions.Object);

            //Act
            var actualClient = service.GetClientOptions();

            //Assert
            Assert.Equal(actualClient, KucoinSocketClientOptions.Default);
        }
    }
}
