namespace ClientBuilder.KucoinBotClient.Models
{
    public class UserCredentials : IUserCredentials
    {
        public KucoinApiCredentials? SpotCredentials { get; }
        public KucoinApiCredentials? FutureCredentials { get; }

        public UserCredentials(
            IApiCredentials spotCredentials,
            IApiCredentials futureCredentials)
        {
            SpotCredentials = GetKucoinApiCredentials(spotCredentials);
            FutureCredentials = GetKucoinApiCredentials(futureCredentials);
        }

        public bool IsEmpty()
            => this.SpotCredentials is null 
            && this.FutureCredentials is null;

        private KucoinApiCredentials? GetKucoinApiCredentials(IApiCredentials credentials)
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
