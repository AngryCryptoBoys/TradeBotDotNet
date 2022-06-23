using Moq;
using Xunit;
using Kucoin.Net.Objects;
using Microsoft.Extensions.Options;
using ClientBuilder.KucoinBotClient.Models;
using ClientBuilder.KucoinBotClient.Services;
using ClientBuilder.KucoinBotClient.Configurations;

namespace ClientBuilder.Tests.KucoinBotClient.Services
{
    public class KucoinClientBuilderServiceTests
    {
        private readonly Mock<IOptions<SpotCredentials>> _mockSpotCredentials;
        private readonly Mock<IOptions<FutureCredentials>> _mockFutureCredentials;
        private readonly Mock<IOptions<ApiRestClientOptions>> _mockApiClientOptions;

        public KucoinClientBuilderServiceTests()
        {
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

            _mockSpotCredentials = new Mock<IOptions<SpotCredentials>>();
            _mockFutureCredentials = new Mock<IOptions<FutureCredentials>>();
            _mockApiClientOptions = new Mock<IOptions<ApiRestClientOptions>>();
            _mockApiClientOptions.Setup(i => i.Value).Returns(apiClientOptions);
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

            var service = new KucoinClientBuilderService(
                userCredentials: userCredentials, 
                options: _mockApiClientOptions.Object);

            //Act
            var actualClient = service.GetClientOptions();

            //Assert
            Assert.Equal(actualClient, KucoinClientOptions.Default);
        }
    }
}
