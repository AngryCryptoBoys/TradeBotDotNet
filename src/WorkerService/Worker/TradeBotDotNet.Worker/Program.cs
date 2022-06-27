IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostBuilder, services) =>
    {
        services.ServicesConfigure(hostBuilder.Configuration);
        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
