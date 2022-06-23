using ClientBuilder.KucoinBotClient.Configurations;
using ClientBuilder.KucoinBotClient.Models;
using ClientBuilder.KucoinBotClient.Services;
using Kucoin.Net.Objects;
using Microsoft.Extensions.Options;
using Moq;
using Xunit;

namespace ClientBuilder.Tests.KucoinBotClient.Services
{
    public class KucoinSocketClientBuilderServiceTests
    {
        private readonly Mock<IOptions<SpotCredentials>> _mockSpotCredentials;
        private readonly Mock<IOptions<FutureCredentials>> _mockFutureCredentials;
        private readonly Mock<IOptions<ApiSocketClientOptions>> _mockApiSocketClientOptions;

        public KucoinSocketClientBuilderServiceTests()
        {
            var spotCredentials = new SpotCredentials()
            {
                ApiKey = "spotCredentials",
                ApiSecret = "spotCredentials",
                ApiPassPhrase = "spotCredentials"
            };
            var futureCredentials = new FutureCredentials()
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

            _mockSpotCredentials = new Mock<IOptions<SpotCredentials>>();
            _mockSpotCredentials.Setup(i => i.Value).Returns(spotCredentials);

            _mockFutureCredentials = new Mock<IOptions<FutureCredentials>>();
            _mockFutureCredentials.Setup(i => i.Value).Returns(futureCredentials);

            _mockApiSocketClientOptions = new Mock<IOptions<ApiSocketClientOptions>>();
            _mockApiSocketClientOptions.Setup(i => i.Value).Returns(apiSocketClientOptions);
        }

        [Fact]
        public void GetClientOptions_InsertEmptyCredentials_ReturnDefaultKucoinSocketClientOptions()
        {
            //Arrange
            _mockSpotCredentials.Setup(i => i.Value).Returns(default(SpotCredentials));
            _mockFutureCredentials.Setup(i => i.Value).Returns(default(FutureCredentials));

            var userCredentials = new UserCredentials(
                spotCredentials: _mockSpotCredentials.Object,
                futureCredentials: _mockFutureCredentials.Object);

            var service = new KucoinSocketClientBuilderService(
                userCredentials: userCredentials,
                options: _mockApiSocketClientOptions.Object);

            //Act
            var actualClient = service.GetClientOptions();

            //Assert
            Assert.Equal(actualClient, KucoinSocketClientOptions.Default);
        }
    }
}
