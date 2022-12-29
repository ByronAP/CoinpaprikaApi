using CoinpaprikaApi;
using Microsoft.Extensions.Logging;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class CoinpaprikaServiceCollectionExtensions
    {
        public static IServiceCollection AddCoinpaprikaApi(this IServiceCollection services)
            => services.AddSingleton<CoinpaprikaClient>();

        public static IServiceCollection AddCoinpaprikaApi(this IServiceCollection services, string apiKey)
            => services.AddSingleton<CoinpaprikaClient>(new CoinpaprikaClient(apiKey: apiKey));

        public static IServiceCollection AddCoinpaprikaApi(this IServiceCollection services, ILogger<CoinpaprikaClient> logger)
            => services.AddSingleton<CoinpaprikaClient>(new CoinpaprikaClient(logger: logger));

        public static IServiceCollection AddCoinpaprikaApi(this IServiceCollection services, string apiKey, ILogger<CoinpaprikaClient> logger)
            => services.AddSingleton<CoinpaprikaClient>(new CoinpaprikaClient(apiKey: apiKey, logger: logger));
    }
}
