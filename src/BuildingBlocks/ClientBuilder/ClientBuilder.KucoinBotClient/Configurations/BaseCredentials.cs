namespace ClientBuilder.KucoinBotClient.Configurations
{
    public class BaseCredentials
    {
        public string ApiKey { get; set; }
        public string ApiSecret { get; set; }
        public string ApiPassPhrase { get; set; }

        internal bool IsEmpty()
            => this.ApiKey is null || this.ApiKey.Equals("") ||
            this.ApiSecret is null || this.ApiSecret.Equals("") ||
            this.ApiPassPhrase is null || this.ApiPassPhrase.Equals("");
    }
}
