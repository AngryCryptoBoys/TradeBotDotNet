using Xunit;
using Kucoin.Net.Objects;
using ClientBuilder.KucoinBotClient.Models;
using ClientBuilder.KucoinBotClient.Services;
using ClientBuilder.KucoinBotClient.Interfaces;
using ClientBuilder.KucoinBotClient.Configurations;

namespace ClientBuilder.Tests.KucoinBotClient.Services
{
    public class KucoinClientBuilderServiceTests
    {
        private readonly IApiCredentials _spotCredentials;
        private readonly IApiCredentials _futureCredentials;
        private readonly IApiRestClientOptions _apiClientOptions;

        public KucoinClientBuilderServiceTests()
        {
            _spotCredentials = new ApiCredentials()
            {
                ApiKey = "ApiKey",
                ApiSecret = "ApiSecret",
                ApiPassPhrase = "ApiPassPhrase"
            };

            _futureCredentials = new ApiCredentials()
            {
                ApiKey = "ApiKey",
                ApiSecret = "ApiSecret",
                ApiPassPhrase = "ApiPassPhrase"
            };

            _apiClientOptions = new ApiRestClientOptions()
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
        }

        [Fact]
        public void GetClientOptions_InsertEmptyCredentials_ReturnDefaultKucoinSocketClientOptions()
        {
            //Arrange
            var userCredentials = new UserCredentials(
                spotCredentials: default(ApiCredentials),
                futureCredentials: default(ApiCredentials));

            var service = new KucoinClientBuilderService(
                userCredentials: userCredentials,
                restClientOptions: _apiClientOptions);

            //Act
            var actualClient = service.GetClientOptions();

            //Assert
            Assert.Equal(actualClient, KucoinClientOptions.Default);
        }
    }
}
