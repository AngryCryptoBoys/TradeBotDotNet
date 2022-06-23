namespace ClientBuilder.KucoinBotClient.Interfaces
{
    public interface IKucoinBotClient
    {
        IKucoinClient RestClient { get; set; }
        IKucoinSocketClient SocketClient { get; set; }
    }
}
