namespace ClientBuilder.KucoinBotClient.Interfaces
{
    public interface IApiProxyConfiguration
    {
        string Host { get; set; }
        int Port { get; set; }
        string Login { get; set; }
        string Password { get; set; }
        ApiProxy? GetApiProxy();
    }
}
