namespace ClientBuilder.KucoinBotClient.Configurations
{
    public class ApiCredentials
    {
        public string ApiKey { get; set; }
        public string ApiSecret { get; set; }
        public string ApiPassPhrase { get; set; }

        public bool IsEmpty()
            => this.ApiKey is null || this.ApiKey.Equals("") ||
            this.ApiSecret is null || this.ApiSecret.Equals("") ||
            this.ApiPassPhrase is null || this.ApiPassPhrase.Equals("");
    }
}
