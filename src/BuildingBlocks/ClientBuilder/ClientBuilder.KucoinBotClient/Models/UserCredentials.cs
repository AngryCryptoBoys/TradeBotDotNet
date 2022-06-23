using Microsoft.Extensions.Options;

namespace ClientBuilder.KucoinBotClient.Models
{
    public class UserCredentials : IUserCredentials
    {
        public KucoinApiCredentials? SpotCredentials { get; }
        public KucoinApiCredentials? FutureCredentials { get; }

        public UserCredentials(
            IOptions<SpotCredentials> spotCredentials,
            IOptions<FutureCredentials> futureCredentials)
        {
            SpotCredentials = GetKucoinApiCredentials(spotCredentials.Value);
            FutureCredentials = GetKucoinApiCredentials(futureCredentials.Value);
        }

        public bool IsEmpty()
            => this.SpotCredentials is null 
            && this.FutureCredentials is null;

        private KucoinApiCredentials? GetKucoinApiCredentials(BaseCredentials credentials)
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
