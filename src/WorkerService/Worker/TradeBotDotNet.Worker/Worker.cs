using TradeBotDotNet.Core.Application.Interfaces;

namespace TradeBotDotNet.Worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly ITradeBotService _tradeBotService;
        private readonly IBotStrategy _botStrategy;

        public Worker(ILogger<Worker> logger,
             ITradeBotService tradeBotService,
             IBotStrategy botStrategy)
        {
            _logger = logger;
            _tradeBotService = tradeBotService;
            _botStrategy = botStrategy;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            await _tradeBotService.StartTradingAsync(_botStrategy, cancellationToken);
        }
    }
}