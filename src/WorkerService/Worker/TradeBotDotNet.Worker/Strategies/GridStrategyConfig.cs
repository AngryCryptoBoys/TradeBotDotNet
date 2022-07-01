namespace TradeBotDotNet.Worker.Strategies
{
    public class GridStrategyConfig
    {
        public string Symbol { get; set; }
        public int StepsCount { get; set; }
        public decimal Step { get; set; }
        public decimal Quantity { get; set; }
        public decimal StartPrice { get; set; }
    }
}
