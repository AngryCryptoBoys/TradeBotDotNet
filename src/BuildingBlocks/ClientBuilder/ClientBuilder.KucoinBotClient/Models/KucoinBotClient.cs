namespace ClientBuilder.KucoinBotClient.Models
{
    public class KucoinBotClient : IKucoinBotClient
    {
        public IKucoinClient RestClient { get; set; }
        public IKucoinSocketClient SocketClient { get; set; }

        public KucoinBotClient(
            IKucoinClientBuilderService clientBuilderService,
            IKucoinSocketClientBuilderService socketClientBuilderService)
        {
            RestClient = clientBuilderService.GetClient();
            SocketClient = socketClientBuilderService.GetClient();
        }
    }
}
