namespace ClientBuilder.KucoinBotClient.Interfaces
{
    public interface IApiCredentials
    {
        string ApiKey { get; set; }
        string ApiSecret { get; set; }
        string ApiPassPhrase { get; set; }
        bool IsEmpty();
    }
}
