namespace ClientBuilder.KucoinBotClient.Models
{
    public class KucoinApiBotClient : IKucoinApiBotClient
    {
        public IKucoinClient RestClient { get; set; }
        public IKucoinSocketClient SocketClient { get; set; }

        public KucoinApiBotClient(
            IKucoinClientBuilderService clientBuilderService,
            IKucoinSocketClientBuilderService socketClientBuilderService)
        {
            RestClient = clientBuilderService.GetClient();
            SocketClient = socketClientBuilderService.GetClient();
        }
    }
}
