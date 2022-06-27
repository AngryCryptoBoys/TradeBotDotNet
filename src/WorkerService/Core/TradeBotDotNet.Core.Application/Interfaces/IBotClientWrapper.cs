namespace TradeBotDotNet.Core.Application.Interfaces
{
    public interface IBotClientWrapper
    {
        Task CreateOrderAsync(
            string symbol,
            OrderSide orderSide,
            NewOrderType orderType,
            decimal quantity,
            decimal? price,
            string? clientOrderId,
            CancellationToken cancellationToken = default);

        Task CancelOrderAsync(
            string orderId,
            string? symbol,
            CancellationToken cancellationToken = default);

        Task OnOrderUpdateAsync(
            Action<DataEvent<KucoinStreamOrderBaseUpdate>> onOrderUpdate,
            CancellationToken cancellationToken = default);
    }
}
