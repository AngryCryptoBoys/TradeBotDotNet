namespace ClientBuilder.KucoinBotClient.Interfaces
{
    public interface IKucoinApiBotClient
    {
        IKucoinClient RestClient { get; set; }
        IKucoinSocketClient SocketClient { get; set; }
    }
}
