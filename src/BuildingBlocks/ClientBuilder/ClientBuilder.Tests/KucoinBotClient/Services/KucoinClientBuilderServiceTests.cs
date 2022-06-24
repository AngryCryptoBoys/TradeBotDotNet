using Moq;
using Xunit;
using Kucoin.Net.Objects;
using ClientBuilder.KucoinBotClient.Models;
using ClientBuilder.KucoinBotClient.Services;
using ClientBuilder.KucoinBotClient.Configurations;
using Microsoft.Extensions.Options;


namespace ClientBuilder.Tests.KucoinBotClient.Services
{
    public class KucoinClientBuilderServiceTests
    {
        private readonly Mock<IOptions<SpotApiCredentials>> _mockSpotCredentials;
        private readonly Mock<IOptions<FutureApiCredentials>> _mockFutureCredentials;
        private readonly Mock<IOptions<ApiRestClientOptions>> _mockApiClientOptions;

        public KucoinClientBuilderServiceTests()
        {
            var spotCredentials = new ApiCredentials()
            {
                ApiKey = "ApiKey",
                ApiSecret = "ApiSecret",
                ApiPassPhrase = "ApiPassPhrase"
            };

            var futureCredentials = new ApiCredentials()
            {
                ApiKey = "ApiKey",
                ApiSecret = "ApiSecret",
                ApiPassPhrase = "ApiPassPhrase"
            };

            var apiClientOptions = new ApiRestClientOptions()
            {
                AutoTimestamp = default,
                RateLimitingBehaviour = 30,
                RequestSecondsTimeout = 30,
                TimestampRecalculationIntervalInSeconds = 30,
                LogLevel = default,
                OutputOriginalData = default,
                BaseAddress = null,
                ApiProxy = null
            };

            _mockSpotCredentials = new Mock<IOptions<SpotApiCredentials>>();
            _mockFutureCredentials = new Mock<IOptions<FutureApiCredentials>>();
            _mockApiClientOptions = new Mock<IOptions<ApiRestClientOptions>>();
            _mockApiClientOptions.Setup(_ => _.Value).Returns(apiClientOptions);
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

            var service = new KucoinClientBuilderService(
                userCredentials: userCredentials,
                restClientOptions: _mockApiClientOptions.Object);

            //Act
            var actualClient = service.GetClientOptions();

            //Assert
            Assert.Equal(actualClient, KucoinClientOptions.Default);
        }
    }
}
