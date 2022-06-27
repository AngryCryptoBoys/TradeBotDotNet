namespace ClientBuilder.KucoinBotClient.Models
{
    public class UserCredentials : IUserCredentials
    {
        public KucoinApiCredentials? SpotCredentials { get; }
        public KucoinApiCredentials? FutureCredentials { get; }

        public UserCredentials(
            IOptions<SpotApiCredentials> spotCredentials,
            IOptions<FutureApiCredentials> futureCredentials)
        {
            SpotCredentials = GetKucoinApiCredentials(spotCredentials.Value);
            FutureCredentials = GetKucoinApiCredentials(futureCredentials.Value);
        }

        public bool IsEmpty()
            => this.SpotCredentials is null 
            && this.FutureCredentials is null;

        private KucoinApiCredentials? GetKucoinApiCredentials(ApiCredentials credentials)
        {
            return credentials is null || credentials.IsEmpty() 
                ? null
                : new KucoinApiCredentials(
                    apiKey: credentials.ApiKey,
                    apiSecret: credentials.ApiSecret,
                    apiPassPhrase: credentials.ApiPassPhrase);
        }
    }
}
