namespace ClientBuilder.KucoinBotClient.Configurations
{
    public class ApiProxyConfiguration : IApiProxyConfiguration
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public ApiProxy? GetApiProxy()
        => new ApiProxy(
            host: this.Host,
            port: this.Port,
            login: this.Login,
            password: this.Password);
    }
}
