namespace TradeBotDotNet.Core.Models
{
    public class BotStreamOrderBaseUpdate
    {
        public string Symbol { get; set; } = string.Empty;
        public string OrderId { get; set; }
        public decimal Price { get; set; }
        public string ClientOrderId { get; set; }
        public decimal Quantity { get; set; }
        public decimal? OldQuantity { get; set; }
    }
}
