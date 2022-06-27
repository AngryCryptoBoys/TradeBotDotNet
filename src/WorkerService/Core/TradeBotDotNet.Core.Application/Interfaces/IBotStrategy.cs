namespace TradeBotDotNet.Core.Application.Interfaces
{
    public interface IBotStrategy
    {
        Task OnInitialAsync(CancellationToken cancellationToken = default(CancellationToken));
        void OnOrderUpdate(DataEvent<KucoinStreamOrderBaseUpdate> onOrderUpdate);
    }
}
