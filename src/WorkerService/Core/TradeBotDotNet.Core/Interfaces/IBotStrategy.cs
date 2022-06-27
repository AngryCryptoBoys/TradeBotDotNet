namespace TradeBotDotNet.Core.Interfaces
{
    public interface IBotStrategy
    {
        Task OnInitialAsync(CancellationToken cancellationToken = default(CancellationToken));
        Task OnOrderUpdateAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
