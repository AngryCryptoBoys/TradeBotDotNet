namespace ClientBuilder.KucoinBotClient.Extensions
{
    public static class IntExtensions
    {
        public static TimeSpan GetSecondsInterval(this int value)
            => TimeSpan.FromSeconds(value);

        public static T GetEnum<T>(this int value) where T : Enum
        {
            var enumValues = Enum.GetValues(typeof(T)) as IEnumerable<int> ?? throw new ArgumentNullException(nameof(T));
            return enumValues.Contains(value)
                ? (T)Enum.ToObject(typeof(T), value)
                : default;
        }
    }
}
