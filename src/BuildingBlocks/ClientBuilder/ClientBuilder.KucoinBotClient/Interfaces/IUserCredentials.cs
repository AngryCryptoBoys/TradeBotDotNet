namespace ClientBuilder.KucoinBotClient.Interfaces
{
    public interface IUserCredentials
    {
        KucoinApiCredentials SpotCredentials { get; }
        KucoinApiCredentials FutureCredentials { get; }
        bool IsEmpty();
    }
}
