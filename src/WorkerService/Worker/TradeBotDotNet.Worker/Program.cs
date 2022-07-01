using ClientBuilder.KucoinBotClient;
using TradeBotDotNet.Core.Application;
using TradeBotDotNet.Core.Application.Interfaces;
using TradeBotDotNet.Infrastructure.ClientWrapper;
using TradeBotDotNet.Worker.Strategies;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostBuilder, services) =>
    {
        services.ServicesConfigure(hostBuilder.Configuration);
        services.AddClientWrapperInfrastructure(hostBuilder.Configuration);
        services.AddCoreApplicationInfrastructure();
        services.AddSingleton<IBotStrategy, GridStrategy>();
        services.Configure<GridStrategyConfig>(hostBuilder.Configuration.GetSection(nameof(GridStrategyConfig)));
        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
