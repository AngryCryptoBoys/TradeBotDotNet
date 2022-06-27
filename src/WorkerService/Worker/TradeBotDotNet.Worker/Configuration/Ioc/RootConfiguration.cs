using TradeBotDotNet.Core.Application;
using TradeBotDotNet.Infrastructure.ClientWrapper;

namespace TradeBotDotNet.Worker.Configuration.Ioc
{
    public static class RootConfiguration
    {
        public static IServiceCollection ServicesConfigure(this IServiceCollection services, IConfiguration configuration)
            => services
                .AddClientWrapperInfrastructure(configuration)
                .AddCoreApplicationInfrastructure();
    }
}
