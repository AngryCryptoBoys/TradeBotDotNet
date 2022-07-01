using CryptoExchange.Net.Sockets;
using Kucoin.Net.Enums;
using Kucoin.Net.Objects.Models.Spot.Socket;
using Microsoft.Extensions.Options;
using TradeBotDotNet.Core.Application.Interfaces;

namespace TradeBotDotNet.Worker.Strategies
{
    public class GridStrategy : IBotStrategy
    {
        private readonly IBotClientWrapper _clientWrapper;
        private readonly ILogger<GridStrategy> _logger;
        private readonly GridStrategyConfig _config;
        public GridStrategy(IBotClientWrapper clientWrapper,
            ILogger<GridStrategy> logger,
            IOptions<GridStrategyConfig> options)
        {
            _clientWrapper = clientWrapper;
            _logger = logger;
            _config = options.Value;
        }
        public async Task OnInitialAsync(CancellationToken cancellationToken = default)
        {
            for (var i = 0; i < _config.StepsCount; i++)
            {
                await _clientWrapper.CreateOrderAsync(
                    _config.Symbol, OrderSide.Buy, NewOrderType.Limit, _config.Quantity, _config.StartPrice - i * _config.Step, $"entry{GetTimestamp()}", cancellationToken);
            }
        }

        public void OnOrderUpdate(DataEvent<KucoinStreamOrderBaseUpdate> onOrderUpdateData)
        {
            var data = onOrderUpdateData.Data;
            _logger.LogInformation(
                $"{data.Symbol} {data.ClientOrderid} {data.OrderId} {data.Price} {data.Quantity} {data.QuantityFilled} {data.Status} {data.Side}");

            if (data.Symbol.Equals(_config.Symbol) && data.UpdateType.Equals(MatchUpdateType.Filled))
            {
                if (data.ClientOrderid.StartsWith("entry"))
                {
                    _clientWrapper.CreateOrderAsync(
                        _config.Symbol, OrderSide.Sell, NewOrderType.Limit, data.QuantityFilled, data.Price + _config.Step, $"tp{GetTimestamp()}", default);
                }
                else if (data.ClientOrderid.StartsWith("tp"))
                {
                    _clientWrapper.CreateOrderAsync(
                        _config.Symbol, OrderSide.Buy, NewOrderType.Limit, data.QuantityFilled, data.Price - _config.Step, $"entry{GetTimestamp()}", default);
                }
            }
        }

        private long GetTimestamp() => DateTimeOffset.Now.ToUnixTimeMilliseconds();
    }
}
