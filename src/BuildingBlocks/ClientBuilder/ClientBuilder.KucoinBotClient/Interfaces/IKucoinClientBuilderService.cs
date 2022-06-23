namespace ClientBuilder.KucoinBotClient.Interfaces
{
    public interface IKucoinClientBuilderService
    {
        IKucoinClient GetClient();
        KucoinClientOptions GetClientOptions();
    }
}
