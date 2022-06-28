using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TradeBotDotNet.Infrastructure.ClientWrapper
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddClientWrapperInfrastructure(this IServiceCollection services, IConfiguration configuration)
            => services
                .AddKucoinClientInfrastructure(configuration)
                .AddSingleton<IBotClientWrapper, BotKucoinClientWrapper>();
    }
}
