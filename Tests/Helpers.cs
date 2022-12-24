namespace Tests
{
    internal static class Helpers
    {
        private const uint API_CALL_INTERVAL_SECONDS = 10;

        private static CoinpaprikaClient? _apiClient = null;
        private static DateTimeOffset _lastCallTime = DateTimeOffset.MinValue;

        internal static async Task<CoinpaprikaClient> GetApiClient()
        {
            if (_apiClient == null)
            {
                var factory = LoggerFactory.Create(x =>
                {
                    x.AddConsole();
                    x.SetMinimumLevel(LogLevel.Debug);
                });
                var logger = factory.CreateLogger<CoinpaprikaClient>();

                _apiClient = new CoinpaprikaClient(logger: logger);
            }

            if (_lastCallTime.AddSeconds(API_CALL_INTERVAL_SECONDS) >= DateTimeOffset.UtcNow)
            {
                await Task.Delay(_lastCallTime.AddSeconds(API_CALL_INTERVAL_SECONDS) - DateTimeOffset.UtcNow); ;
            }

            _lastCallTime = DateTimeOffset.UtcNow;

            return _apiClient;
        }
    }
}
