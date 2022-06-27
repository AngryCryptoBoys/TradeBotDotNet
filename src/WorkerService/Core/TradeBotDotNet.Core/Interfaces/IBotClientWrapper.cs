using CryptoExchange.Net.Sockets;
using Kucoin.Net.Objects.Models.Spot.Socket;

namespace TradeBotDotNet.Core.Interfaces
{
    public interface IBotClientWrapper
    {
        Task CreateOrderAsync(string symbol,
            int orderSide,
            int orderType,
            decimal quantity,
            decimal? price,
            string? accountId,
            string? clientOrderId,
            CancellationToken cancellationToken = default(CancellationToken));
        Task DeleteOrderAsync(
            string orderId, 
            string? symbol, 
            CancellationToken cancellationToken = default);
        Task OnChangeOrderAsync(
            Action<DataEvent<KucoinStreamOrderBaseUpdate>> onOrderData,
            Action<DataEvent<KucoinStreamOrderMatchUpdate>> onTradeData,
            CancellationToken cancellationToken = default);
    }
}
