namespace ClientBuilder.KucoinBotClient.Interfaces
{
    public interface IKucoinSocketClientBuilderService
    {
        IKucoinSocketClient GetClient();
        KucoinSocketClientOptions GetClientOptions();
    }
}
