using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ClientBuilder.KucoinBotClient
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddKucoinClientInfrastructure(this IServiceCollection services, IConfiguration configuration)
            => services
                .Configure<SpotApiCredentials>(configuration.GetSection(nameof(SpotApiCredentials)))
                .Configure<FutureApiCredentials>(configuration.GetSection(nameof(FutureApiCredentials)))
                .Configure<ApiRestClientOptions>(configuration.GetSection(nameof(ApiRestClientOptions)))
                .Configure<ApiSocketClientOptions>(configuration.GetSection(nameof(ApiSocketClientOptions)))
                .AddSingleton<IUserCredentials, UserCredentials>()
                .AddSingleton<IKucoinClientBuilderService, KucoinClientBuilderService>()
                .AddSingleton<IKucoinSocketClientBuilderService, KucoinSocketClientBuilderService>()
                .AddSingleton<IKucoinApiBotClient, KucoinApiBotClient>();
    }
}
