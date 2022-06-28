namespace TradeBotDotNet.Core.Application.Interfaces
{
    public interface ITradeBotService
    {
        Task StartTradingAsync(
            IBotStrategy botStrategy,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}
