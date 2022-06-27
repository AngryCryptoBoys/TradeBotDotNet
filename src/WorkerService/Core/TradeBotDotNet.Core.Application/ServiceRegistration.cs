using Microsoft.Extensions.DependencyInjection;

namespace TradeBotDotNet.Core.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddCoreApplicationInfrastructure(this IServiceCollection services)
            => services
                .AddSingleton<ITradeBotService, TradeBotService>();
    }
}
