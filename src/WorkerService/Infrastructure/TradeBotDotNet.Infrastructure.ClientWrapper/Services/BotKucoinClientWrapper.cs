namespace TradeBotDotNet.Infrastructure.ClientWrapper.Services
{
    public class BotKucoinClientWrapper : IBotClientWrapper
    {
        private readonly IKucoinApiBotClient _kucoinApiBotClient;

        public BotKucoinClientWrapper(IKucoinApiBotClient kucoinApiBotClient)
        {
            _kucoinApiBotClient = kucoinApiBotClient;
        }

        public async Task CreateOrderAsync(
            string symbol,
            OrderSide orderSide,
            NewOrderType orderType,
            decimal quantity,
            decimal? price, 
            string? clientOrderId,
            CancellationToken cancellationToken = default)
            => await _kucoinApiBotClient
                .RestClient
                .SpotApi
                .Trading
                .PlaceOrderAsync(
                    symbol: symbol, 
                    side: orderSide, 
                    type: orderType, 
                    quantity: quantity,
                    price: price, 
                    clientOrderId: clientOrderId,
                    ct: cancellationToken);

        public async Task CancelOrderAsync(
            string orderId,
            string? symbol,
            CancellationToken cancellationToken = default)
            => await _kucoinApiBotClient
                .RestClient
                .SpotApi
                .Trading
                .CancelOrderAsync(
                    orderId: orderId, 
                    ct: cancellationToken);

        public async Task OnOrderUpdateAsync(
            Action<DataEvent<KucoinStreamOrderBaseUpdate>> onOrderUpdate, 
            CancellationToken cancellationToken = default)
            => await _kucoinApiBotClient
                .SocketClient
                .SpotStreams
                .SubscribeToOrderUpdatesAsync(
                    onOrderData: onOrderUpdate,
                    onTradeData: null,
                    ct: cancellationToken);
    }
}
