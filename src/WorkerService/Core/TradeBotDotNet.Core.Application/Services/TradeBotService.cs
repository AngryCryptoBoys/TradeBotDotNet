namespace TradeBotDotNet.Core.Application.Services
{
    public class TradeBotService : ITradeBotService
    {
        private readonly IBotClientWrapper _clientWrapper;

        public TradeBotService(IBotClientWrapper clientWrapper)
        {
            _clientWrapper = clientWrapper;
        }

        public async Task StartTradingAsync(
            IBotStrategy botStrategy,
            CancellationToken cancellationToken = default)
        {
            await _clientWrapper.OnOrderUpdateAsync(
                onOrderUpdate: botStrategy.OnOrderUpdate,
                cancellationToken: cancellationToken);
            await botStrategy.OnInitialAsync(cancellationToken);
        }
    }
}
